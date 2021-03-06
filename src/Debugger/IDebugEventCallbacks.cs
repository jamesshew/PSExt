﻿// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Runtime.InteropServices;

#pragma warning disable 1591

namespace Microsoft.Diagnostics.Runtime.Interop
{
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("337be28b-5036-4d72-b6bf-c45fbb9f2eaa")]
	public interface IDebugEventCallbacks
	{
		[PreserveSig]
		int GetInterestMask(
			[Out] out DEBUG_EVENT Mask);

		[PreserveSig]
		int Breakpoint(
			[In, MarshalAs(UnmanagedType.Interface)] IDebugBreakpoint Bp);

		[PreserveSig]
		int Exception(
			[In] ref EXCEPTION_RECORD64 Exception,
			[In] uint FirstChance);

		[PreserveSig]
		int CreateThread(
			[In] ulong Handle,
			[In] ulong DataOffset,
			[In] ulong StartOffset);

		[PreserveSig]
		int ExitThread(
			[In] uint ExitCode);

		[PreserveSig]
		int CreateProcess(
			[In] ulong ImageFileHandle,
			[In] ulong Handle,
			[In] ulong BaseOffset,
			[In] uint ModuleSize,
			[In, MarshalAs(UnmanagedType.LPStr)] string ModuleName,
			[In, MarshalAs(UnmanagedType.LPStr)] string ImageName,
			[In] uint CheckSum,
			[In] uint TimeDateStamp,
			[In] ulong InitialThreadHandle,
			[In] ulong ThreadDataOffset,
			[In] ulong StartOffset);

		[PreserveSig]
		int ExitProcess(
			[In] uint ExitCode);

		[PreserveSig]
		int LoadModule(
			[In] ulong ImageFileHandle,
			[In] ulong BaseOffset,
			[In] uint ModuleSize,
			[In, MarshalAs(UnmanagedType.LPStr)] string ModuleName,
			[In, MarshalAs(UnmanagedType.LPStr)] string ImageName,
			[In] uint CheckSum,
			[In] uint TimeDateStamp);

		[PreserveSig]
		int UnloadModule(
			[In, MarshalAs(UnmanagedType.LPStr)] string ImageBaseName,
			[In] ulong BaseOffset);

		[PreserveSig]
		int SystemError(
			[In] uint Error,
			[In] uint Level);

		[PreserveSig]
		int SessionStatus(
			[In] DEBUG_SESSION Status);

		[PreserveSig]
		int ChangeDebuggeeState(
			[In] DEBUG_CDS Flags,
			[In] ulong Argument);

		[PreserveSig]
		int ChangeEngineState(
			[In] DEBUG_CES Flags,
			[In] ulong Argument);

		[PreserveSig]
		int ChangeSymbolState(
			[In] DEBUG_CSS Flags,
			[In] ulong Argument);
	}
}