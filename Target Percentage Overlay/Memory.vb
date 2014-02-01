Public Class Memory
    ' TWEAK THE FOLLOWING MEMORY ADDRESSES AND OFFSETS SHOULD ANYTHING BREAK WITH FUTURE PATCHES!
    Private Const PTR_TO_TARGET_ENTITY = &H1072770
    Private Const PTR_TO_FOCUS_ENTITY = &H10727B0
    Private Const ENTITY_OFFSET_HP = &H16A0
    Private Const ENTITY_OFFSET_HP_MAX = &H16A4
    Private Const ENTITY_OFFSET_MP = &H16A8
    Private Const ENTITY_OFFSET_MP_MAX = &H16AC
    Private Const ENTITY_OFFSET_TP = &H16B0

    Private Declare Function OpenProcess Lib "kernel32.dll" (ByVal dwDesiredAcess As UInt32, ByVal bInheritHandle As Boolean, ByVal dwProcessId As Int32) As IntPtr
    Private Declare Function ReadProcessMemory Lib "kernel32" (ByVal hProcess As IntPtr, ByVal lpBaseAddress As IntPtr, ByVal lpBuffer() As Byte, ByVal iSize As Integer, ByRef lpNumberOfBytesRead As Integer) As Boolean
    Private Declare Function CloseHandle Lib "kernel32.dll" (ByVal hObject As IntPtr) As Boolean

    Private Const FFXIV_PROCESS As String = "ffxiv"
    Private Const PROCESS_VM_READ As UInteger = 16
    Private Const PROCESS_QUERY_INFORMATION As UInteger = 1024

    Private ffxiv_proc As Process
    Private ffxiv_proc_hdl As IntPtr = IntPtr.Zero

    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        DetachFromProcess()
    End Sub

    Public Function AttachToProcess(ByVal index As Integer) As Boolean
        If ffxiv_proc_hdl <> IntPtr.Zero Then Return True ' attached already

        Try
            Dim procs As Process() = Process.GetProcessesByName(FFXIV_PROCESS)
            If procs.Length > 0 Then
                If Not IsNothing(procs(index)) Then
                    ffxiv_proc = procs(index)
                    ffxiv_proc_hdl = OpenProcess(PROCESS_VM_READ Or PROCESS_QUERY_INFORMATION, False, ffxiv_proc.Id)
                End If
            End If
        Catch ex As Exception
            Debug.Print(ex.StackTrace & vbCrLf)
            DetachFromProcess()
        End Try

        Return ffxiv_proc_hdl <> IntPtr.Zero
    End Function

    Public Sub DetachFromProcess()
        If ffxiv_proc_hdl <> IntPtr.Zero Then CloseHandle(ffxiv_proc_hdl)
        ffxiv_proc_hdl = IntPtr.Zero
    End Sub

    Public Enum EntityValueType
        HP
        HP_MAX
        MP
        MP_MAX
        TP
    End Enum

    Public Function GetValue(ByVal entity As Settings.EntityType, ByVal value_type As EntityValueType) As Int32
        Dim base_addr As Int32 = ffxiv_proc.MainModule.BaseAddress
        Select Case entity
            Case Settings.EntityType.TARGET
                Return GetEntityValue(base_addr + PTR_TO_TARGET_ENTITY, value_type)
            Case Settings.EntityType.FOCUS
                Return GetEntityValue(IntPtr.Add(base_addr, PTR_TO_FOCUS_ENTITY), value_type)
            Case Else
                Return 0
        End Select
    End Function

    Private Function ReadInt32(ByVal addr As IntPtr) As Int32
        Dim _dataBytes(3) As Byte
        ReadProcessMemory(ffxiv_proc_hdl, addr, _dataBytes, 4, vbNull)
        Return BitConverter.ToInt32(_dataBytes, 0)
    End Function

    Private Function GetEntityValue(ByVal entity_ptr_addr As Int32, ByVal value_type As EntityValueType) As Int32
        Dim entity_addr As Int32 = ReadInt32(entity_ptr_addr)
        If entity_addr = 0 Then Return 0

        Select Case value_type
            Case EntityValueType.HP
                Return ReadInt32(entity_addr + ENTITY_OFFSET_HP)
            Case EntityValueType.HP_MAX
                Return ReadInt32(entity_addr + ENTITY_OFFSET_HP_MAX)
            Case EntityValueType.MP
                Return ReadInt32(entity_addr + ENTITY_OFFSET_MP)
            Case EntityValueType.MP_MAX
                Return ReadInt32(entity_addr + ENTITY_OFFSET_MP_MAX)
            Case EntityValueType.TP
                Return ReadInt32(entity_addr + ENTITY_OFFSET_TP)
            Case Else
                Return 0
        End Select
    End Function
End Class
