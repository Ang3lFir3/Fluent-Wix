//-------------------------------------------------------------------------------------------------
// <copyright file="resrutil.h" company="Microsoft">
//    Copyright (c) Microsoft Corporation.  All rights reserved.
//    
//    The use and distribution terms for this software are covered by the
//    Common Public License 1.0 (http://opensource.org/licenses/cpl.php)
//    which can be found in the file CPL.TXT at the root of this distribution.
//    By using this software in any fashion, you are agreeing to be bound by
//    the terms of this license.
//    
//    You must not remove this notice, or any other, from this software.
// </copyright>
// 
// <summary>
//    Resource read helper functions.
// </summary>
//-------------------------------------------------------------------------------------------------

#pragma once


#ifdef __cplusplus
extern "C" {
#endif

HRESULT DAPI ResGetStringLangId(
    __in_opt LPCWSTR wzPath,
    __in UINT uID,
    __out WORD *pwLangId
    );

HRESULT DAPI ResReadString(
    __in HINSTANCE hinst,
    __in UINT uID,
    __out LPWSTR* ppwzString
    );

HRESULT DAPI ResReadStringAnsi(
    __in HINSTANCE hinst,
    __in UINT uID,
    __inout LPSTR* ppszString
    );

HRESULT DAPI ResReadData(
    __in_opt HINSTANCE hinst,
    __in LPCSTR szDataName,
    __out PVOID *ppv,
    __out DWORD *pcb
    );

HRESULT DAPI ResExportDataToFile(
    __in LPCSTR szDataName,
    __in LPCWSTR wzTargetFile,
    __in DWORD dwCreationDisposition
    );

#ifdef __cplusplus
}
#endif

