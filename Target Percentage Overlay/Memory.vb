Public Class Memory
    '
    ' Updating Memory Addresses:
    '   These memory addresses need updating if the overlay stops functioning as a result of a FFXIV patch.
    '   The first number is the offset from the base address of ffxiv.exe of a pointer. The next number is
    '   the offset from that pointer's address, repeat.
    '
    '   These were the default pointers for the ffxiv.exe process as of 2/26/2014.
    '
    Private TARGET_ENTITY() As Int32 = {&HE912A8, &H4E0}
    Private FOCUS_ENTITY() As Int32 = {&HE912F0, &H4E0}

    Private Const ENTITY_OFFSET_HP = &H1678
    Private Const ENTITY_OFFSET_HP_MAX = &H167C
    Private Const ENTITY_OFFSET_MP = &H1680
    Private Const ENTITY_OFFSET_MP_MAX = &H1684
    Private Const ENTITY_OFFSET_TP = &H1688

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

    Private Function Deref(addr As IntPtr, offset As Int32) As Int32
        Return ReadInt32(IntPtr.Add(addr, offset))
    End Function

    Public Function GetValue(ByVal entity As Settings.EntityType, ByVal value_type As EntityValueType) As Integer
        Dim addr = ffxiv_proc.MainModule.BaseAddress
        Select Case entity
            Case Settings.EntityType.TARGET
                For Each offset In TARGET_ENTITY
                    addr = Deref(addr, offset)
                Next
                Return GetEntityValue(addr, value_type)
            Case Settings.EntityType.FOCUS
                For Each offset In FOCUS_ENTITY
                    addr = Deref(addr, offset)
                Next
                Return GetEntityValue(addr, value_type)
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

    Private Function GetEntityValue(ByVal entity_addr As IntPtr, ByVal value_type As EntityValueType) As Integer
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
