Public Class Memory
    '
    ' Updating Memory Addresses:
    '   These memory addresses need updating if the overlay stops functioning as a result of a FFXIV patch.
    '   Aftwards, be sure to increment the VERSION number in Settings.vb, then you're finished with the update.
    '
    '   These were the default pointers for the ffxiv.exe process as of 2/1/2014. - Cord
    '
    Public Const DEFAULT_PTR_TO_TARGET_ENTITY = &HE902F4
    Public Const DEFAULT_PTR_TO_FOCUS_ENTITY = &HE902F0
    Private Const ENTITY_OFFSET_HP = &H1838
    Private Const ENTITY_OFFSET_HP_MAX = &H183C
    Private Const ENTITY_OFFSET_MP = &H1840
    Private Const ENTITY_OFFSET_MP_MAX = &H1844
    Private Const ENTITY_OFFSET_TP = &H1848

    Public Enum EntityValueType
        HP
        HP_MAX
        MP
        MP_MAX
        TP
    End Enum

    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        DetachFromProcess()
    End Sub

    Public Function AttachToProcess(ByVal index As Integer) As Boolean
        If index <> ffxiv_proc_index Then DetachFromProcess()
        If ffxiv_proc_hdl <> IntPtr.Zero Then Return True ' attached already

        Try
            Dim procs As Process() = Process.GetProcessesByName(FFXIV_PROCESS)
            If procs.Length > 0 Then
                If Not IsNothing(procs(index)) Then
                    ffxiv_proc = procs(index)
                    ffxiv_proc_hdl = OpenProcess(PROCESS_VM_READ Or PROCESS_QUERY_INFORMATION, False, ffxiv_proc.Id)
                    ffxiv_proc_index = index
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
        ffxiv_proc_index = -1
    End Sub

    Public Function GetValue(ByVal entity As Settings.EntityType, ByVal value_type As EntityValueType) As Integer
        Dim base_addr As IntPtr = ffxiv_proc.MainModule.BaseAddress
        Select Case entity
            Case Settings.EntityType.TARGET
                Return GetEntityValue(IntPtr.Add(base_addr, My.Settings.target_pointer_address), value_type)
            Case Settings.EntityType.FOCUS
                Return GetEntityValue(IntPtr.Add(base_addr, My.Settings.focus_pointer_address), value_type)
            Case Else
                Return 0
        End Select
    End Function

    Private Function ReadInt32(ByVal addr As IntPtr) As Int32
        Dim _dataBytes(4) As Byte
        ReadProcessMemory(ffxiv_proc_hdl, addr, _dataBytes, 4, vbNull)
        Return BitConverter.ToInt32(_dataBytes, 0)
    End Function

    Private Function ReadInt16(ByVal addr As IntPtr) As Int16
        Dim _dataBytes(2) As Byte
        ReadProcessMemory(ffxiv_proc_hdl, addr, _dataBytes, 2, vbNull)
        Return BitConverter.ToInt16(_dataBytes, 0)
    End Function

    Private Function GetEntityValue(ByVal entity_ptr_addr As IntPtr, ByVal value_type As EntityValueType) As Integer
        Dim entity_addr As IntPtr = ReadInt32(entity_ptr_addr)
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
                Return ReadInt16(entity_addr + ENTITY_OFFSET_TP)
            Case Else
                Return 0
        End Select
    End Function

    Private Declare Function OpenProcess Lib "kernel32.dll" (ByVal dwDesiredAcess As UInt32, ByVal bInheritHandle As Boolean, ByVal dwProcessId As Int32) As IntPtr
    Private Declare Function ReadProcessMemory Lib "kernel32" (ByVal hProcess As IntPtr, ByVal lpBaseAddress As IntPtr, ByVal lpBuffer() As Byte, ByVal iSize As Integer, ByRef lpNumberOfBytesRead As Integer) As Boolean
    Private Declare Function CloseHandle Lib "kernel32.dll" (ByVal hObject As IntPtr) As Boolean

    Private Const FFXIV_PROCESS As String = "ffxiv"
    Private Const PROCESS_VM_READ As UInteger = 16
    Private Const PROCESS_QUERY_INFORMATION As UInteger = 1024

    Private ffxiv_proc As Process
    Private ffxiv_proc_hdl As IntPtr = IntPtr.Zero
    Private ffxiv_proc_index As Integer = -1
End Class
