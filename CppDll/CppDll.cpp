#include "pch.h"
#include "CppDll.h"
#include <combaseapi.h>
#include <string>

static int g_Count = 0;
static HANDLE g_Event = INVALID_HANDLE_VALUE;

extern "C" LPCWSTR __cdecl GetMemAllocStr(const std::wstring & str)
{
	size_t buf_size = (str.size() + 1) * sizeof(wchar_t);
	wchar_t* buf = (wchar_t*)CoTaskMemAlloc(buf_size);
	if (buf)
	{
		memset(buf, 0, buf_size);
		if (str.size() > 0)
		{
			memcpy(buf, str.c_str(), buf_size);
		}
	}
	return buf;
}

extern "C" void __cdecl CreateServer()
{
	g_Event = CreateEvent(NULL, FALSE, FALSE, L"MyMsgEventName");

}

extern "C" void __cdecl MessageSignal()
{
	SetEvent(g_Event); // signal to the C# client that 
}

extern "C" LPCWSTR __cdecl ReadMessage()
{
	std::wstring msg = std::to_wstring(++g_Count);
	return GetMemAllocStr(msg); // C# shall automatically free this string
}

extern "C" void __cdecl Cleanup()
{
	if (g_Event != INVALID_HANDLE_VALUE)
	{
		CloseHandle(g_Event);
		g_Event = INVALID_HANDLE_VALUE;
	}
}
