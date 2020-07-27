#pragma once

#include <windows.h>

extern "C" __declspec(dllexport) void __cdecl CreateServer();

extern "C" __declspec(dllexport) void __cdecl Cleanup();

extern "C" __declspec(dllexport) void __cdecl MessageSignal();

extern "C" __declspec(dllexport) LPCWSTR __cdecl ReadMessage();
