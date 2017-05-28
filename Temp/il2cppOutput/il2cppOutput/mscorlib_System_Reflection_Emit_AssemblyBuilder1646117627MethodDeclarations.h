#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>
#include <assert.h>
#include <exception>

// System.Reflection.Emit.AssemblyBuilder
struct AssemblyBuilder_t1646117627;
// System.String
struct String_t;
// System.Reflection.Module[]
struct ModuleU5BU5D_t3593287923;
// System.Type[]
struct TypeU5BU5D_t1664964607;
// System.Reflection.ManifestResourceInfo
struct ManifestResourceInfo_t2035432027;
// System.String[]
struct StringU5BU5D_t1642385972;
// System.IO.Stream
struct Stream_t3255436806;
// System.Exception
struct Exception_t1927440687;
// System.Reflection.AssemblyName
struct AssemblyName_t894705941;

#include "codegen/il2cpp-codegen.h"
#include "mscorlib_System_String2029220233.h"

// System.String System.Reflection.Emit.AssemblyBuilder::get_Location()
extern "C"  String_t* AssemblyBuilder_get_Location_m554656855 (AssemblyBuilder_t1646117627 * __this, const MethodInfo* method) IL2CPP_METHOD_ATTR;
// System.Reflection.Module[] System.Reflection.Emit.AssemblyBuilder::GetModulesInternal()
extern "C"  ModuleU5BU5D_t3593287923* AssemblyBuilder_GetModulesInternal_m3379844831 (AssemblyBuilder_t1646117627 * __this, const MethodInfo* method) IL2CPP_METHOD_ATTR;
// System.Type[] System.Reflection.Emit.AssemblyBuilder::GetTypes(System.Boolean)
extern "C"  TypeU5BU5D_t1664964607* AssemblyBuilder_GetTypes_m2527954992 (AssemblyBuilder_t1646117627 * __this, bool ___exportedOnly0, const MethodInfo* method) IL2CPP_METHOD_ATTR;
// System.Reflection.ManifestResourceInfo System.Reflection.Emit.AssemblyBuilder::GetManifestResourceInfo(System.String)
extern "C"  ManifestResourceInfo_t2035432027 * AssemblyBuilder_GetManifestResourceInfo_m526368075 (AssemblyBuilder_t1646117627 * __this, String_t* ___resourceName0, const MethodInfo* method) IL2CPP_METHOD_ATTR;
// System.String[] System.Reflection.Emit.AssemblyBuilder::GetManifestResourceNames()
extern "C"  StringU5BU5D_t1642385972* AssemblyBuilder_GetManifestResourceNames_m3593199824 (AssemblyBuilder_t1646117627 * __this, const MethodInfo* method) IL2CPP_METHOD_ATTR;
// System.IO.Stream System.Reflection.Emit.AssemblyBuilder::GetManifestResourceStream(System.String)
extern "C"  Stream_t3255436806 * AssemblyBuilder_GetManifestResourceStream_m3920095515 (AssemblyBuilder_t1646117627 * __this, String_t* ___name0, const MethodInfo* method) IL2CPP_METHOD_ATTR;
// System.Boolean System.Reflection.Emit.AssemblyBuilder::get_IsCompilerContext()
extern "C"  bool AssemblyBuilder_get_IsCompilerContext_m2864230005 (AssemblyBuilder_t1646117627 * __this, const MethodInfo* method) IL2CPP_METHOD_ATTR;
// System.Exception System.Reflection.Emit.AssemblyBuilder::not_supported()
extern "C"  Exception_t1927440687 * AssemblyBuilder_not_supported_m383946865 (AssemblyBuilder_t1646117627 * __this, const MethodInfo* method) IL2CPP_METHOD_ATTR;
// System.Reflection.AssemblyName System.Reflection.Emit.AssemblyBuilder::UnprotectedGetName()
extern "C"  AssemblyName_t894705941 * AssemblyBuilder_UnprotectedGetName_m2328641134 (AssemblyBuilder_t1646117627 * __this, const MethodInfo* method) IL2CPP_METHOD_ATTR;
