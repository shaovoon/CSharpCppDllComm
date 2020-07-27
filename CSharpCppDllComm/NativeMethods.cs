using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace CSharpCppDllComm
{
    public static class NativeMethods
    {
        // D3DVisualization.dll , MandyDll
        [DllImport("CppDll.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void CreateServer();

        [DllImport("CppDll.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void Cleanup();

        [DllImport("CppDll.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void MessageSignal();

        [DllImport("CppDll.dll", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.LPWStr)]
        public static extern String ReadMessage();

    }
}
