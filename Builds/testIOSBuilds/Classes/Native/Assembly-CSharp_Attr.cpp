#include "pch-cpp.hpp"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif


#include <limits>
#include <stdint.h>



// System.Char[]
struct CharU5BU5D_t7B7FC5BC8091AA3B9CB0B29CDD80B5EE9254AA34;
// System.Runtime.CompilerServices.CompilationRelaxationsAttribute
struct CompilationRelaxationsAttribute_t661FDDC06629BDA607A42BD660944F039FE03AFF;
// System.Runtime.CompilerServices.CompilerGeneratedAttribute
struct CompilerGeneratedAttribute_t39106AB982658D7A94C27DEF3C48DB2F5F7CD75C;
// System.Diagnostics.DebuggableAttribute
struct DebuggableAttribute_tA8054EBD0FC7511695D494B690B5771658E3191B;
// System.Diagnostics.DebuggerBrowsableAttribute
struct DebuggerBrowsableAttribute_t2FA4793AD1982F5150E07D26822ED5953CD90F53;
// UnityEngine.HeaderAttribute
struct HeaderAttribute_t9B431E6BA0524D46406D9C413D6A71CB5F2DD1AB;
// UnityEngine.HideInInspector
struct HideInInspector_tDD5B9D3AD8D48C93E23FE6CA3ECDA5589D60CCDA;
// UnityEngine.RangeAttribute
struct RangeAttribute_t14A6532D68168764C15E7CF1FDABCD99CB32D0C5;
// System.Runtime.CompilerServices.RuntimeCompatibilityAttribute
struct RuntimeCompatibilityAttribute_tFF99AB2963098F9CBCD47A20D9FD3D51C17C1C80;
// UnityEngine.SerializeField
struct SerializeField_t6B23EE6CC99B21C3EBD946352112832A70E67E25;
// System.String
struct String_t;



IL2CPP_EXTERN_C_BEGIN
IL2CPP_EXTERN_C_END

#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Object


// System.Attribute
struct Attribute_t037CA9D9F3B742C063DB364D2EEBBF9FC5772C71  : public RuntimeObject
{
public:

public:
};


// System.String
struct String_t  : public RuntimeObject
{
public:
	// System.Int32 System.String::m_stringLength
	int32_t ___m_stringLength_0;
	// System.Char System.String::m_firstChar
	Il2CppChar ___m_firstChar_1;

public:
	inline static int32_t get_offset_of_m_stringLength_0() { return static_cast<int32_t>(offsetof(String_t, ___m_stringLength_0)); }
	inline int32_t get_m_stringLength_0() const { return ___m_stringLength_0; }
	inline int32_t* get_address_of_m_stringLength_0() { return &___m_stringLength_0; }
	inline void set_m_stringLength_0(int32_t value)
	{
		___m_stringLength_0 = value;
	}

	inline static int32_t get_offset_of_m_firstChar_1() { return static_cast<int32_t>(offsetof(String_t, ___m_firstChar_1)); }
	inline Il2CppChar get_m_firstChar_1() const { return ___m_firstChar_1; }
	inline Il2CppChar* get_address_of_m_firstChar_1() { return &___m_firstChar_1; }
	inline void set_m_firstChar_1(Il2CppChar value)
	{
		___m_firstChar_1 = value;
	}
};

struct String_t_StaticFields
{
public:
	// System.String System.String::Empty
	String_t* ___Empty_5;

public:
	inline static int32_t get_offset_of_Empty_5() { return static_cast<int32_t>(offsetof(String_t_StaticFields, ___Empty_5)); }
	inline String_t* get_Empty_5() const { return ___Empty_5; }
	inline String_t** get_address_of_Empty_5() { return &___Empty_5; }
	inline void set_Empty_5(String_t* value)
	{
		___Empty_5 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___Empty_5), (void*)value);
	}
};


// System.ValueType
struct ValueType_tDBF999C1B75C48C68621878250DBF6CDBCF51E52  : public RuntimeObject
{
public:

public:
};

// Native definition for P/Invoke marshalling of System.ValueType
struct ValueType_tDBF999C1B75C48C68621878250DBF6CDBCF51E52_marshaled_pinvoke
{
};
// Native definition for COM marshalling of System.ValueType
struct ValueType_tDBF999C1B75C48C68621878250DBF6CDBCF51E52_marshaled_com
{
};

// System.Boolean
struct Boolean_t07D1E3F34E4813023D64F584DFF7B34C9D922F37 
{
public:
	// System.Boolean System.Boolean::m_value
	bool ___m_value_0;

public:
	inline static int32_t get_offset_of_m_value_0() { return static_cast<int32_t>(offsetof(Boolean_t07D1E3F34E4813023D64F584DFF7B34C9D922F37, ___m_value_0)); }
	inline bool get_m_value_0() const { return ___m_value_0; }
	inline bool* get_address_of_m_value_0() { return &___m_value_0; }
	inline void set_m_value_0(bool value)
	{
		___m_value_0 = value;
	}
};

struct Boolean_t07D1E3F34E4813023D64F584DFF7B34C9D922F37_StaticFields
{
public:
	// System.String System.Boolean::TrueString
	String_t* ___TrueString_5;
	// System.String System.Boolean::FalseString
	String_t* ___FalseString_6;

public:
	inline static int32_t get_offset_of_TrueString_5() { return static_cast<int32_t>(offsetof(Boolean_t07D1E3F34E4813023D64F584DFF7B34C9D922F37_StaticFields, ___TrueString_5)); }
	inline String_t* get_TrueString_5() const { return ___TrueString_5; }
	inline String_t** get_address_of_TrueString_5() { return &___TrueString_5; }
	inline void set_TrueString_5(String_t* value)
	{
		___TrueString_5 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___TrueString_5), (void*)value);
	}

	inline static int32_t get_offset_of_FalseString_6() { return static_cast<int32_t>(offsetof(Boolean_t07D1E3F34E4813023D64F584DFF7B34C9D922F37_StaticFields, ___FalseString_6)); }
	inline String_t* get_FalseString_6() const { return ___FalseString_6; }
	inline String_t** get_address_of_FalseString_6() { return &___FalseString_6; }
	inline void set_FalseString_6(String_t* value)
	{
		___FalseString_6 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___FalseString_6), (void*)value);
	}
};


// System.Runtime.CompilerServices.CompilationRelaxationsAttribute
struct CompilationRelaxationsAttribute_t661FDDC06629BDA607A42BD660944F039FE03AFF  : public Attribute_t037CA9D9F3B742C063DB364D2EEBBF9FC5772C71
{
public:
	// System.Int32 System.Runtime.CompilerServices.CompilationRelaxationsAttribute::m_relaxations
	int32_t ___m_relaxations_0;

public:
	inline static int32_t get_offset_of_m_relaxations_0() { return static_cast<int32_t>(offsetof(CompilationRelaxationsAttribute_t661FDDC06629BDA607A42BD660944F039FE03AFF, ___m_relaxations_0)); }
	inline int32_t get_m_relaxations_0() const { return ___m_relaxations_0; }
	inline int32_t* get_address_of_m_relaxations_0() { return &___m_relaxations_0; }
	inline void set_m_relaxations_0(int32_t value)
	{
		___m_relaxations_0 = value;
	}
};


// System.Runtime.CompilerServices.CompilerGeneratedAttribute
struct CompilerGeneratedAttribute_t39106AB982658D7A94C27DEF3C48DB2F5F7CD75C  : public Attribute_t037CA9D9F3B742C063DB364D2EEBBF9FC5772C71
{
public:

public:
};


// System.Enum
struct Enum_t23B90B40F60E677A8025267341651C94AE079CDA  : public ValueType_tDBF999C1B75C48C68621878250DBF6CDBCF51E52
{
public:

public:
};

struct Enum_t23B90B40F60E677A8025267341651C94AE079CDA_StaticFields
{
public:
	// System.Char[] System.Enum::enumSeperatorCharArray
	CharU5BU5D_t7B7FC5BC8091AA3B9CB0B29CDD80B5EE9254AA34* ___enumSeperatorCharArray_0;

public:
	inline static int32_t get_offset_of_enumSeperatorCharArray_0() { return static_cast<int32_t>(offsetof(Enum_t23B90B40F60E677A8025267341651C94AE079CDA_StaticFields, ___enumSeperatorCharArray_0)); }
	inline CharU5BU5D_t7B7FC5BC8091AA3B9CB0B29CDD80B5EE9254AA34* get_enumSeperatorCharArray_0() const { return ___enumSeperatorCharArray_0; }
	inline CharU5BU5D_t7B7FC5BC8091AA3B9CB0B29CDD80B5EE9254AA34** get_address_of_enumSeperatorCharArray_0() { return &___enumSeperatorCharArray_0; }
	inline void set_enumSeperatorCharArray_0(CharU5BU5D_t7B7FC5BC8091AA3B9CB0B29CDD80B5EE9254AA34* value)
	{
		___enumSeperatorCharArray_0 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___enumSeperatorCharArray_0), (void*)value);
	}
};

// Native definition for P/Invoke marshalling of System.Enum
struct Enum_t23B90B40F60E677A8025267341651C94AE079CDA_marshaled_pinvoke
{
};
// Native definition for COM marshalling of System.Enum
struct Enum_t23B90B40F60E677A8025267341651C94AE079CDA_marshaled_com
{
};

// UnityEngine.HideInInspector
struct HideInInspector_tDD5B9D3AD8D48C93E23FE6CA3ECDA5589D60CCDA  : public Attribute_t037CA9D9F3B742C063DB364D2EEBBF9FC5772C71
{
public:

public:
};


// UnityEngine.PropertyAttribute
struct PropertyAttribute_t4A352471DF625C56C811E27AC86B7E1CE6444052  : public Attribute_t037CA9D9F3B742C063DB364D2EEBBF9FC5772C71
{
public:

public:
};


// System.Runtime.CompilerServices.RuntimeCompatibilityAttribute
struct RuntimeCompatibilityAttribute_tFF99AB2963098F9CBCD47A20D9FD3D51C17C1C80  : public Attribute_t037CA9D9F3B742C063DB364D2EEBBF9FC5772C71
{
public:
	// System.Boolean System.Runtime.CompilerServices.RuntimeCompatibilityAttribute::m_wrapNonExceptionThrows
	bool ___m_wrapNonExceptionThrows_0;

public:
	inline static int32_t get_offset_of_m_wrapNonExceptionThrows_0() { return static_cast<int32_t>(offsetof(RuntimeCompatibilityAttribute_tFF99AB2963098F9CBCD47A20D9FD3D51C17C1C80, ___m_wrapNonExceptionThrows_0)); }
	inline bool get_m_wrapNonExceptionThrows_0() const { return ___m_wrapNonExceptionThrows_0; }
	inline bool* get_address_of_m_wrapNonExceptionThrows_0() { return &___m_wrapNonExceptionThrows_0; }
	inline void set_m_wrapNonExceptionThrows_0(bool value)
	{
		___m_wrapNonExceptionThrows_0 = value;
	}
};


// UnityEngine.SerializeField
struct SerializeField_t6B23EE6CC99B21C3EBD946352112832A70E67E25  : public Attribute_t037CA9D9F3B742C063DB364D2EEBBF9FC5772C71
{
public:

public:
};


// System.Void
struct Void_t700C6383A2A510C2CF4DD86DABD5CA9FF70ADAC5 
{
public:
	union
	{
		struct
		{
		};
		uint8_t Void_t700C6383A2A510C2CF4DD86DABD5CA9FF70ADAC5__padding[1];
	};

public:
};


// System.Diagnostics.DebuggerBrowsableState
struct DebuggerBrowsableState_t2A824ECEB650CFABB239FD0918FCC88A09B45091 
{
public:
	// System.Int32 System.Diagnostics.DebuggerBrowsableState::value__
	int32_t ___value___2;

public:
	inline static int32_t get_offset_of_value___2() { return static_cast<int32_t>(offsetof(DebuggerBrowsableState_t2A824ECEB650CFABB239FD0918FCC88A09B45091, ___value___2)); }
	inline int32_t get_value___2() const { return ___value___2; }
	inline int32_t* get_address_of_value___2() { return &___value___2; }
	inline void set_value___2(int32_t value)
	{
		___value___2 = value;
	}
};


// UnityEngine.HeaderAttribute
struct HeaderAttribute_t9B431E6BA0524D46406D9C413D6A71CB5F2DD1AB  : public PropertyAttribute_t4A352471DF625C56C811E27AC86B7E1CE6444052
{
public:
	// System.String UnityEngine.HeaderAttribute::header
	String_t* ___header_0;

public:
	inline static int32_t get_offset_of_header_0() { return static_cast<int32_t>(offsetof(HeaderAttribute_t9B431E6BA0524D46406D9C413D6A71CB5F2DD1AB, ___header_0)); }
	inline String_t* get_header_0() const { return ___header_0; }
	inline String_t** get_address_of_header_0() { return &___header_0; }
	inline void set_header_0(String_t* value)
	{
		___header_0 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___header_0), (void*)value);
	}
};


// UnityEngine.RangeAttribute
struct RangeAttribute_t14A6532D68168764C15E7CF1FDABCD99CB32D0C5  : public PropertyAttribute_t4A352471DF625C56C811E27AC86B7E1CE6444052
{
public:
	// System.Single UnityEngine.RangeAttribute::min
	float ___min_0;
	// System.Single UnityEngine.RangeAttribute::max
	float ___max_1;

public:
	inline static int32_t get_offset_of_min_0() { return static_cast<int32_t>(offsetof(RangeAttribute_t14A6532D68168764C15E7CF1FDABCD99CB32D0C5, ___min_0)); }
	inline float get_min_0() const { return ___min_0; }
	inline float* get_address_of_min_0() { return &___min_0; }
	inline void set_min_0(float value)
	{
		___min_0 = value;
	}

	inline static int32_t get_offset_of_max_1() { return static_cast<int32_t>(offsetof(RangeAttribute_t14A6532D68168764C15E7CF1FDABCD99CB32D0C5, ___max_1)); }
	inline float get_max_1() const { return ___max_1; }
	inline float* get_address_of_max_1() { return &___max_1; }
	inline void set_max_1(float value)
	{
		___max_1 = value;
	}
};


// System.Diagnostics.DebuggableAttribute/DebuggingModes
struct DebuggingModes_t279D5B9C012ABA935887CB73C5A63A1F46AF08A8 
{
public:
	// System.Int32 System.Diagnostics.DebuggableAttribute/DebuggingModes::value__
	int32_t ___value___2;

public:
	inline static int32_t get_offset_of_value___2() { return static_cast<int32_t>(offsetof(DebuggingModes_t279D5B9C012ABA935887CB73C5A63A1F46AF08A8, ___value___2)); }
	inline int32_t get_value___2() const { return ___value___2; }
	inline int32_t* get_address_of_value___2() { return &___value___2; }
	inline void set_value___2(int32_t value)
	{
		___value___2 = value;
	}
};


// System.Diagnostics.DebuggableAttribute
struct DebuggableAttribute_tA8054EBD0FC7511695D494B690B5771658E3191B  : public Attribute_t037CA9D9F3B742C063DB364D2EEBBF9FC5772C71
{
public:
	// System.Diagnostics.DebuggableAttribute/DebuggingModes System.Diagnostics.DebuggableAttribute::m_debuggingModes
	int32_t ___m_debuggingModes_0;

public:
	inline static int32_t get_offset_of_m_debuggingModes_0() { return static_cast<int32_t>(offsetof(DebuggableAttribute_tA8054EBD0FC7511695D494B690B5771658E3191B, ___m_debuggingModes_0)); }
	inline int32_t get_m_debuggingModes_0() const { return ___m_debuggingModes_0; }
	inline int32_t* get_address_of_m_debuggingModes_0() { return &___m_debuggingModes_0; }
	inline void set_m_debuggingModes_0(int32_t value)
	{
		___m_debuggingModes_0 = value;
	}
};


// System.Diagnostics.DebuggerBrowsableAttribute
struct DebuggerBrowsableAttribute_t2FA4793AD1982F5150E07D26822ED5953CD90F53  : public Attribute_t037CA9D9F3B742C063DB364D2EEBBF9FC5772C71
{
public:
	// System.Diagnostics.DebuggerBrowsableState System.Diagnostics.DebuggerBrowsableAttribute::state
	int32_t ___state_0;

public:
	inline static int32_t get_offset_of_state_0() { return static_cast<int32_t>(offsetof(DebuggerBrowsableAttribute_t2FA4793AD1982F5150E07D26822ED5953CD90F53, ___state_0)); }
	inline int32_t get_state_0() const { return ___state_0; }
	inline int32_t* get_address_of_state_0() { return &___state_0; }
	inline void set_state_0(int32_t value)
	{
		___state_0 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif



// System.Void System.Diagnostics.DebuggableAttribute::.ctor(System.Diagnostics.DebuggableAttribute/DebuggingModes)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void DebuggableAttribute__ctor_m7FF445C8435494A4847123A668D889E692E55550 (DebuggableAttribute_tA8054EBD0FC7511695D494B690B5771658E3191B * __this, int32_t ___modes0, const RuntimeMethod* method);
// System.Void System.Runtime.CompilerServices.CompilationRelaxationsAttribute::.ctor(System.Int32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void CompilationRelaxationsAttribute__ctor_mAC3079EBC4EEAB474EED8208EF95DB39C922333B (CompilationRelaxationsAttribute_t661FDDC06629BDA607A42BD660944F039FE03AFF * __this, int32_t ___relaxations0, const RuntimeMethod* method);
// System.Void System.Runtime.CompilerServices.RuntimeCompatibilityAttribute::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void RuntimeCompatibilityAttribute__ctor_m551DDF1438CE97A984571949723F30F44CF7317C (RuntimeCompatibilityAttribute_tFF99AB2963098F9CBCD47A20D9FD3D51C17C1C80 * __this, const RuntimeMethod* method);
// System.Void System.Runtime.CompilerServices.RuntimeCompatibilityAttribute::set_WrapNonExceptionThrows(System.Boolean)
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void RuntimeCompatibilityAttribute_set_WrapNonExceptionThrows_m8562196F90F3EBCEC23B5708EE0332842883C490_inline (RuntimeCompatibilityAttribute_tFF99AB2963098F9CBCD47A20D9FD3D51C17C1C80 * __this, bool ___value0, const RuntimeMethod* method);
// System.Void System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void CompilerGeneratedAttribute__ctor_m9DC3E4E2DA76FE93948D44199213E2E924DCBE35 (CompilerGeneratedAttribute_t39106AB982658D7A94C27DEF3C48DB2F5F7CD75C * __this, const RuntimeMethod* method);
// System.Void System.Diagnostics.DebuggerBrowsableAttribute::.ctor(System.Diagnostics.DebuggerBrowsableState)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void DebuggerBrowsableAttribute__ctor_mAA8BCC1E418754685F320B14A08AC226E76346E5 (DebuggerBrowsableAttribute_t2FA4793AD1982F5150E07D26822ED5953CD90F53 * __this, int32_t ___state0, const RuntimeMethod* method);
// System.Void UnityEngine.HeaderAttribute::.ctor(System.String)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void HeaderAttribute__ctor_m601319E0BCE8C44A9E79B2C0ABAAD0FEF46A9F1E (HeaderAttribute_t9B431E6BA0524D46406D9C413D6A71CB5F2DD1AB * __this, String_t* ___header0, const RuntimeMethod* method);
// System.Void UnityEngine.SerializeField::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void SerializeField__ctor_mDE6A7673BA2C1FAD03CFEC65C6D473CC37889DD3 (SerializeField_t6B23EE6CC99B21C3EBD946352112832A70E67E25 * __this, const RuntimeMethod* method);
// System.Void UnityEngine.RangeAttribute::.ctor(System.Single,System.Single)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void RangeAttribute__ctor_mC74D39A9F20DD2A0D4174F05785ABE4F0DAEF000 (RangeAttribute_t14A6532D68168764C15E7CF1FDABCD99CB32D0C5 * __this, float ___min0, float ___max1, const RuntimeMethod* method);
// System.Void UnityEngine.HideInInspector::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void HideInInspector__ctor_mE2B7FB1D206A74BA583C7812CDB4EBDD83EB66F9 (HideInInspector_tDD5B9D3AD8D48C93E23FE6CA3ECDA5589D60CCDA * __this, const RuntimeMethod* method);
static void AssemblyU2DCSharp_CustomAttributesCacheGenerator(CustomAttributesCache* cache)
{
	{
		DebuggableAttribute_tA8054EBD0FC7511695D494B690B5771658E3191B * tmp = (DebuggableAttribute_tA8054EBD0FC7511695D494B690B5771658E3191B *)cache->attributes[0];
		DebuggableAttribute__ctor_m7FF445C8435494A4847123A668D889E692E55550(tmp, 263LL, NULL);
	}
	{
		CompilationRelaxationsAttribute_t661FDDC06629BDA607A42BD660944F039FE03AFF * tmp = (CompilationRelaxationsAttribute_t661FDDC06629BDA607A42BD660944F039FE03AFF *)cache->attributes[1];
		CompilationRelaxationsAttribute__ctor_mAC3079EBC4EEAB474EED8208EF95DB39C922333B(tmp, 8LL, NULL);
	}
	{
		RuntimeCompatibilityAttribute_tFF99AB2963098F9CBCD47A20D9FD3D51C17C1C80 * tmp = (RuntimeCompatibilityAttribute_tFF99AB2963098F9CBCD47A20D9FD3D51C17C1C80 *)cache->attributes[2];
		RuntimeCompatibilityAttribute__ctor_m551DDF1438CE97A984571949723F30F44CF7317C(tmp, NULL);
		RuntimeCompatibilityAttribute_set_WrapNonExceptionThrows_m8562196F90F3EBCEC23B5708EE0332842883C490_inline(tmp, true, NULL);
	}
}
static void CameraController_tCFCE51ADE50A46097682FD3E2CEA53100D84E7E0_CustomAttributesCacheGenerator_U3CMainCameraU3Ek__BackingField(CustomAttributesCache* cache)
{
	{
		CompilerGeneratedAttribute_t39106AB982658D7A94C27DEF3C48DB2F5F7CD75C * tmp = (CompilerGeneratedAttribute_t39106AB982658D7A94C27DEF3C48DB2F5F7CD75C *)cache->attributes[0];
		CompilerGeneratedAttribute__ctor_m9DC3E4E2DA76FE93948D44199213E2E924DCBE35(tmp, NULL);
	}
	{
		DebuggerBrowsableAttribute_t2FA4793AD1982F5150E07D26822ED5953CD90F53 * tmp = (DebuggerBrowsableAttribute_t2FA4793AD1982F5150E07D26822ED5953CD90F53 *)cache->attributes[1];
		DebuggerBrowsableAttribute__ctor_mAA8BCC1E418754685F320B14A08AC226E76346E5(tmp, 0LL, NULL);
	}
}
static void CameraController_tCFCE51ADE50A46097682FD3E2CEA53100D84E7E0_CustomAttributesCacheGenerator_CameraController_get_MainCamera_m4891C6270550DC5362E9C5FDF2628AF6C755B22B(CustomAttributesCache* cache)
{
	{
		CompilerGeneratedAttribute_t39106AB982658D7A94C27DEF3C48DB2F5F7CD75C * tmp = (CompilerGeneratedAttribute_t39106AB982658D7A94C27DEF3C48DB2F5F7CD75C *)cache->attributes[0];
		CompilerGeneratedAttribute__ctor_m9DC3E4E2DA76FE93948D44199213E2E924DCBE35(tmp, NULL);
	}
}
static void CameraController_tCFCE51ADE50A46097682FD3E2CEA53100D84E7E0_CustomAttributesCacheGenerator_CameraController_set_MainCamera_m8420EBB666CB7556D4E7C84E42FAA3064EBDC990(CustomAttributesCache* cache)
{
	{
		CompilerGeneratedAttribute_t39106AB982658D7A94C27DEF3C48DB2F5F7CD75C * tmp = (CompilerGeneratedAttribute_t39106AB982658D7A94C27DEF3C48DB2F5F7CD75C *)cache->attributes[0];
		CompilerGeneratedAttribute__ctor_m9DC3E4E2DA76FE93948D44199213E2E924DCBE35(tmp, NULL);
	}
}
static void GoalController_t4AFE584FC90F1D61939DAEEA167B3C902D469493_CustomAttributesCacheGenerator_U3CinstanceU3Ek__BackingField(CustomAttributesCache* cache)
{
	{
		CompilerGeneratedAttribute_t39106AB982658D7A94C27DEF3C48DB2F5F7CD75C * tmp = (CompilerGeneratedAttribute_t39106AB982658D7A94C27DEF3C48DB2F5F7CD75C *)cache->attributes[0];
		CompilerGeneratedAttribute__ctor_m9DC3E4E2DA76FE93948D44199213E2E924DCBE35(tmp, NULL);
	}
	{
		DebuggerBrowsableAttribute_t2FA4793AD1982F5150E07D26822ED5953CD90F53 * tmp = (DebuggerBrowsableAttribute_t2FA4793AD1982F5150E07D26822ED5953CD90F53 *)cache->attributes[1];
		DebuggerBrowsableAttribute__ctor_mAA8BCC1E418754685F320B14A08AC226E76346E5(tmp, 0LL, NULL);
	}
}
static void GoalController_t4AFE584FC90F1D61939DAEEA167B3C902D469493_CustomAttributesCacheGenerator_U3CGoalReachedU3Ek__BackingField(CustomAttributesCache* cache)
{
	{
		CompilerGeneratedAttribute_t39106AB982658D7A94C27DEF3C48DB2F5F7CD75C * tmp = (CompilerGeneratedAttribute_t39106AB982658D7A94C27DEF3C48DB2F5F7CD75C *)cache->attributes[0];
		CompilerGeneratedAttribute__ctor_m9DC3E4E2DA76FE93948D44199213E2E924DCBE35(tmp, NULL);
	}
	{
		DebuggerBrowsableAttribute_t2FA4793AD1982F5150E07D26822ED5953CD90F53 * tmp = (DebuggerBrowsableAttribute_t2FA4793AD1982F5150E07D26822ED5953CD90F53 *)cache->attributes[1];
		DebuggerBrowsableAttribute__ctor_mAA8BCC1E418754685F320B14A08AC226E76346E5(tmp, 0LL, NULL);
	}
}
static void GoalController_t4AFE584FC90F1D61939DAEEA167B3C902D469493_CustomAttributesCacheGenerator_AbsorberColorChanged(CustomAttributesCache* cache)
{
	{
		CompilerGeneratedAttribute_t39106AB982658D7A94C27DEF3C48DB2F5F7CD75C * tmp = (CompilerGeneratedAttribute_t39106AB982658D7A94C27DEF3C48DB2F5F7CD75C *)cache->attributes[0];
		CompilerGeneratedAttribute__ctor_m9DC3E4E2DA76FE93948D44199213E2E924DCBE35(tmp, NULL);
	}
	{
		DebuggerBrowsableAttribute_t2FA4793AD1982F5150E07D26822ED5953CD90F53 * tmp = (DebuggerBrowsableAttribute_t2FA4793AD1982F5150E07D26822ED5953CD90F53 *)cache->attributes[1];
		DebuggerBrowsableAttribute__ctor_mAA8BCC1E418754685F320B14A08AC226E76346E5(tmp, 0LL, NULL);
	}
}
static void GoalController_t4AFE584FC90F1D61939DAEEA167B3C902D469493_CustomAttributesCacheGenerator_GoalController_get_instance_m2B44E6A94369DD896C6BFA851538621A41A9D806(CustomAttributesCache* cache)
{
	{
		CompilerGeneratedAttribute_t39106AB982658D7A94C27DEF3C48DB2F5F7CD75C * tmp = (CompilerGeneratedAttribute_t39106AB982658D7A94C27DEF3C48DB2F5F7CD75C *)cache->attributes[0];
		CompilerGeneratedAttribute__ctor_m9DC3E4E2DA76FE93948D44199213E2E924DCBE35(tmp, NULL);
	}
}
static void GoalController_t4AFE584FC90F1D61939DAEEA167B3C902D469493_CustomAttributesCacheGenerator_GoalController_set_instance_mB6591465AA7E953E9140D7814805D071C3EEDB1B(CustomAttributesCache* cache)
{
	{
		CompilerGeneratedAttribute_t39106AB982658D7A94C27DEF3C48DB2F5F7CD75C * tmp = (CompilerGeneratedAttribute_t39106AB982658D7A94C27DEF3C48DB2F5F7CD75C *)cache->attributes[0];
		CompilerGeneratedAttribute__ctor_m9DC3E4E2DA76FE93948D44199213E2E924DCBE35(tmp, NULL);
	}
}
static void GoalController_t4AFE584FC90F1D61939DAEEA167B3C902D469493_CustomAttributesCacheGenerator_GoalController_get_GoalReached_mEA91245C02041A7EA7C8B2FAC9115F952E0990EF(CustomAttributesCache* cache)
{
	{
		CompilerGeneratedAttribute_t39106AB982658D7A94C27DEF3C48DB2F5F7CD75C * tmp = (CompilerGeneratedAttribute_t39106AB982658D7A94C27DEF3C48DB2F5F7CD75C *)cache->attributes[0];
		CompilerGeneratedAttribute__ctor_m9DC3E4E2DA76FE93948D44199213E2E924DCBE35(tmp, NULL);
	}
}
static void GoalController_t4AFE584FC90F1D61939DAEEA167B3C902D469493_CustomAttributesCacheGenerator_GoalController_set_GoalReached_mAEFAFD2EC61C7BA247AE1505338FAA8C9E65318E(CustomAttributesCache* cache)
{
	{
		CompilerGeneratedAttribute_t39106AB982658D7A94C27DEF3C48DB2F5F7CD75C * tmp = (CompilerGeneratedAttribute_t39106AB982658D7A94C27DEF3C48DB2F5F7CD75C *)cache->attributes[0];
		CompilerGeneratedAttribute__ctor_m9DC3E4E2DA76FE93948D44199213E2E924DCBE35(tmp, NULL);
	}
}
static void GoalController_t4AFE584FC90F1D61939DAEEA167B3C902D469493_CustomAttributesCacheGenerator_GoalController_add_AbsorberColorChanged_m619AE242C05CB7CDA4CA9085346622C4B737948A(CustomAttributesCache* cache)
{
	{
		CompilerGeneratedAttribute_t39106AB982658D7A94C27DEF3C48DB2F5F7CD75C * tmp = (CompilerGeneratedAttribute_t39106AB982658D7A94C27DEF3C48DB2F5F7CD75C *)cache->attributes[0];
		CompilerGeneratedAttribute__ctor_m9DC3E4E2DA76FE93948D44199213E2E924DCBE35(tmp, NULL);
	}
}
static void GoalController_t4AFE584FC90F1D61939DAEEA167B3C902D469493_CustomAttributesCacheGenerator_GoalController_remove_AbsorberColorChanged_mD306F88EECAA52A28EBD761F310D633C62C36723(CustomAttributesCache* cache)
{
	{
		CompilerGeneratedAttribute_t39106AB982658D7A94C27DEF3C48DB2F5F7CD75C * tmp = (CompilerGeneratedAttribute_t39106AB982658D7A94C27DEF3C48DB2F5F7CD75C *)cache->attributes[0];
		CompilerGeneratedAttribute__ctor_m9DC3E4E2DA76FE93948D44199213E2E924DCBE35(tmp, NULL);
	}
}
static void InputController_tE5796D3B3202F143B79AC438A06019484963D990_CustomAttributesCacheGenerator_U3CinstanceU3Ek__BackingField(CustomAttributesCache* cache)
{
	{
		CompilerGeneratedAttribute_t39106AB982658D7A94C27DEF3C48DB2F5F7CD75C * tmp = (CompilerGeneratedAttribute_t39106AB982658D7A94C27DEF3C48DB2F5F7CD75C *)cache->attributes[0];
		CompilerGeneratedAttribute__ctor_m9DC3E4E2DA76FE93948D44199213E2E924DCBE35(tmp, NULL);
	}
	{
		DebuggerBrowsableAttribute_t2FA4793AD1982F5150E07D26822ED5953CD90F53 * tmp = (DebuggerBrowsableAttribute_t2FA4793AD1982F5150E07D26822ED5953CD90F53 *)cache->attributes[1];
		DebuggerBrowsableAttribute__ctor_mAA8BCC1E418754685F320B14A08AC226E76346E5(tmp, 0LL, NULL);
	}
}
static void InputController_tE5796D3B3202F143B79AC438A06019484963D990_CustomAttributesCacheGenerator_TouchMove(CustomAttributesCache* cache)
{
	{
		CompilerGeneratedAttribute_t39106AB982658D7A94C27DEF3C48DB2F5F7CD75C * tmp = (CompilerGeneratedAttribute_t39106AB982658D7A94C27DEF3C48DB2F5F7CD75C *)cache->attributes[0];
		CompilerGeneratedAttribute__ctor_m9DC3E4E2DA76FE93948D44199213E2E924DCBE35(tmp, NULL);
	}
	{
		DebuggerBrowsableAttribute_t2FA4793AD1982F5150E07D26822ED5953CD90F53 * tmp = (DebuggerBrowsableAttribute_t2FA4793AD1982F5150E07D26822ED5953CD90F53 *)cache->attributes[1];
		DebuggerBrowsableAttribute__ctor_mAA8BCC1E418754685F320B14A08AC226E76346E5(tmp, 0LL, NULL);
	}
}
static void InputController_tE5796D3B3202F143B79AC438A06019484963D990_CustomAttributesCacheGenerator_InputController_get_instance_m49A4333C4704C9D9AB1863EA780CFE3858827B7C(CustomAttributesCache* cache)
{
	{
		CompilerGeneratedAttribute_t39106AB982658D7A94C27DEF3C48DB2F5F7CD75C * tmp = (CompilerGeneratedAttribute_t39106AB982658D7A94C27DEF3C48DB2F5F7CD75C *)cache->attributes[0];
		CompilerGeneratedAttribute__ctor_m9DC3E4E2DA76FE93948D44199213E2E924DCBE35(tmp, NULL);
	}
}
static void InputController_tE5796D3B3202F143B79AC438A06019484963D990_CustomAttributesCacheGenerator_InputController_set_instance_mC1A3D0D7E301EC5ECA681E7BA183759A10D99576(CustomAttributesCache* cache)
{
	{
		CompilerGeneratedAttribute_t39106AB982658D7A94C27DEF3C48DB2F5F7CD75C * tmp = (CompilerGeneratedAttribute_t39106AB982658D7A94C27DEF3C48DB2F5F7CD75C *)cache->attributes[0];
		CompilerGeneratedAttribute__ctor_m9DC3E4E2DA76FE93948D44199213E2E924DCBE35(tmp, NULL);
	}
}
static void InputController_tE5796D3B3202F143B79AC438A06019484963D990_CustomAttributesCacheGenerator_InputController_add_TouchMove_m5F81F5F08739552E0F6B041734665211CE8293B6(CustomAttributesCache* cache)
{
	{
		CompilerGeneratedAttribute_t39106AB982658D7A94C27DEF3C48DB2F5F7CD75C * tmp = (CompilerGeneratedAttribute_t39106AB982658D7A94C27DEF3C48DB2F5F7CD75C *)cache->attributes[0];
		CompilerGeneratedAttribute__ctor_m9DC3E4E2DA76FE93948D44199213E2E924DCBE35(tmp, NULL);
	}
}
static void InputController_tE5796D3B3202F143B79AC438A06019484963D990_CustomAttributesCacheGenerator_InputController_remove_TouchMove_m993F68CEE893436D9FE952682F02FDCC129B66A3(CustomAttributesCache* cache)
{
	{
		CompilerGeneratedAttribute_t39106AB982658D7A94C27DEF3C48DB2F5F7CD75C * tmp = (CompilerGeneratedAttribute_t39106AB982658D7A94C27DEF3C48DB2F5F7CD75C *)cache->attributes[0];
		CompilerGeneratedAttribute__ctor_m9DC3E4E2DA76FE93948D44199213E2E924DCBE35(tmp, NULL);
	}
}
static void LevelController_tE4C446AC0B9C5216612A4CD60E1C878E8329A430_CustomAttributesCacheGenerator_U3CTilesU3Ek__BackingField(CustomAttributesCache* cache)
{
	{
		CompilerGeneratedAttribute_t39106AB982658D7A94C27DEF3C48DB2F5F7CD75C * tmp = (CompilerGeneratedAttribute_t39106AB982658D7A94C27DEF3C48DB2F5F7CD75C *)cache->attributes[0];
		CompilerGeneratedAttribute__ctor_m9DC3E4E2DA76FE93948D44199213E2E924DCBE35(tmp, NULL);
	}
	{
		DebuggerBrowsableAttribute_t2FA4793AD1982F5150E07D26822ED5953CD90F53 * tmp = (DebuggerBrowsableAttribute_t2FA4793AD1982F5150E07D26822ED5953CD90F53 *)cache->attributes[1];
		DebuggerBrowsableAttribute__ctor_mAA8BCC1E418754685F320B14A08AC226E76346E5(tmp, 0LL, NULL);
	}
}
static void LevelController_tE4C446AC0B9C5216612A4CD60E1C878E8329A430_CustomAttributesCacheGenerator_LevelController_get_Tiles_mAFC52CA935ACD0055263E3BF94D75A8CB0ADC89D(CustomAttributesCache* cache)
{
	{
		CompilerGeneratedAttribute_t39106AB982658D7A94C27DEF3C48DB2F5F7CD75C * tmp = (CompilerGeneratedAttribute_t39106AB982658D7A94C27DEF3C48DB2F5F7CD75C *)cache->attributes[0];
		CompilerGeneratedAttribute__ctor_m9DC3E4E2DA76FE93948D44199213E2E924DCBE35(tmp, NULL);
	}
}
static void LevelController_tE4C446AC0B9C5216612A4CD60E1C878E8329A430_CustomAttributesCacheGenerator_LevelController_set_Tiles_mB8C60D16F190CBE8F3C3070DF776C295CEAFADBD(CustomAttributesCache* cache)
{
	{
		CompilerGeneratedAttribute_t39106AB982658D7A94C27DEF3C48DB2F5F7CD75C * tmp = (CompilerGeneratedAttribute_t39106AB982658D7A94C27DEF3C48DB2F5F7CD75C *)cache->attributes[0];
		CompilerGeneratedAttribute__ctor_m9DC3E4E2DA76FE93948D44199213E2E924DCBE35(tmp, NULL);
	}
}
static void SaveController_tFB7D347083FDE3C8BCB09893AE1DAF9766740B15_CustomAttributesCacheGenerator_U3CinstanceU3Ek__BackingField(CustomAttributesCache* cache)
{
	{
		CompilerGeneratedAttribute_t39106AB982658D7A94C27DEF3C48DB2F5F7CD75C * tmp = (CompilerGeneratedAttribute_t39106AB982658D7A94C27DEF3C48DB2F5F7CD75C *)cache->attributes[0];
		CompilerGeneratedAttribute__ctor_m9DC3E4E2DA76FE93948D44199213E2E924DCBE35(tmp, NULL);
	}
	{
		DebuggerBrowsableAttribute_t2FA4793AD1982F5150E07D26822ED5953CD90F53 * tmp = (DebuggerBrowsableAttribute_t2FA4793AD1982F5150E07D26822ED5953CD90F53 *)cache->attributes[1];
		DebuggerBrowsableAttribute__ctor_mAA8BCC1E418754685F320B14A08AC226E76346E5(tmp, 0LL, NULL);
	}
}
static void SaveController_tFB7D347083FDE3C8BCB09893AE1DAF9766740B15_CustomAttributesCacheGenerator_SaveController_get_instance_mA09584B45DCD65F69DB02F9F7686F0BE03DD61D0(CustomAttributesCache* cache)
{
	{
		CompilerGeneratedAttribute_t39106AB982658D7A94C27DEF3C48DB2F5F7CD75C * tmp = (CompilerGeneratedAttribute_t39106AB982658D7A94C27DEF3C48DB2F5F7CD75C *)cache->attributes[0];
		CompilerGeneratedAttribute__ctor_m9DC3E4E2DA76FE93948D44199213E2E924DCBE35(tmp, NULL);
	}
}
static void SaveController_tFB7D347083FDE3C8BCB09893AE1DAF9766740B15_CustomAttributesCacheGenerator_SaveController_set_instance_m66389D2DC0D57241662D987E01D3C22247641259(CustomAttributesCache* cache)
{
	{
		CompilerGeneratedAttribute_t39106AB982658D7A94C27DEF3C48DB2F5F7CD75C * tmp = (CompilerGeneratedAttribute_t39106AB982658D7A94C27DEF3C48DB2F5F7CD75C *)cache->attributes[0];
		CompilerGeneratedAttribute__ctor_m9DC3E4E2DA76FE93948D44199213E2E924DCBE35(tmp, NULL);
	}
}
static void Laser_t128A4BF0CB0C0349676F7C0999823F8A05E87ABA_CustomAttributesCacheGenerator_U3CViewU3Ek__BackingField(CustomAttributesCache* cache)
{
	{
		CompilerGeneratedAttribute_t39106AB982658D7A94C27DEF3C48DB2F5F7CD75C * tmp = (CompilerGeneratedAttribute_t39106AB982658D7A94C27DEF3C48DB2F5F7CD75C *)cache->attributes[0];
		CompilerGeneratedAttribute__ctor_m9DC3E4E2DA76FE93948D44199213E2E924DCBE35(tmp, NULL);
	}
	{
		DebuggerBrowsableAttribute_t2FA4793AD1982F5150E07D26822ED5953CD90F53 * tmp = (DebuggerBrowsableAttribute_t2FA4793AD1982F5150E07D26822ED5953CD90F53 *)cache->attributes[1];
		DebuggerBrowsableAttribute__ctor_mAA8BCC1E418754685F320B14A08AC226E76346E5(tmp, 0LL, NULL);
	}
}
static void Laser_t128A4BF0CB0C0349676F7C0999823F8A05E87ABA_CustomAttributesCacheGenerator_U3CLaserColorU3Ek__BackingField(CustomAttributesCache* cache)
{
	{
		CompilerGeneratedAttribute_t39106AB982658D7A94C27DEF3C48DB2F5F7CD75C * tmp = (CompilerGeneratedAttribute_t39106AB982658D7A94C27DEF3C48DB2F5F7CD75C *)cache->attributes[0];
		CompilerGeneratedAttribute__ctor_m9DC3E4E2DA76FE93948D44199213E2E924DCBE35(tmp, NULL);
	}
	{
		DebuggerBrowsableAttribute_t2FA4793AD1982F5150E07D26822ED5953CD90F53 * tmp = (DebuggerBrowsableAttribute_t2FA4793AD1982F5150E07D26822ED5953CD90F53 *)cache->attributes[1];
		DebuggerBrowsableAttribute__ctor_mAA8BCC1E418754685F320B14A08AC226E76346E5(tmp, 0LL, NULL);
	}
}
static void Laser_t128A4BF0CB0C0349676F7C0999823F8A05E87ABA_CustomAttributesCacheGenerator_U3CDirectionU3Ek__BackingField(CustomAttributesCache* cache)
{
	{
		CompilerGeneratedAttribute_t39106AB982658D7A94C27DEF3C48DB2F5F7CD75C * tmp = (CompilerGeneratedAttribute_t39106AB982658D7A94C27DEF3C48DB2F5F7CD75C *)cache->attributes[0];
		CompilerGeneratedAttribute__ctor_m9DC3E4E2DA76FE93948D44199213E2E924DCBE35(tmp, NULL);
	}
	{
		DebuggerBrowsableAttribute_t2FA4793AD1982F5150E07D26822ED5953CD90F53 * tmp = (DebuggerBrowsableAttribute_t2FA4793AD1982F5150E07D26822ED5953CD90F53 *)cache->attributes[1];
		DebuggerBrowsableAttribute__ctor_mAA8BCC1E418754685F320B14A08AC226E76346E5(tmp, 0LL, NULL);
	}
}
static void Laser_t128A4BF0CB0C0349676F7C0999823F8A05E87ABA_CustomAttributesCacheGenerator_U3CLineU3Ek__BackingField(CustomAttributesCache* cache)
{
	{
		CompilerGeneratedAttribute_t39106AB982658D7A94C27DEF3C48DB2F5F7CD75C * tmp = (CompilerGeneratedAttribute_t39106AB982658D7A94C27DEF3C48DB2F5F7CD75C *)cache->attributes[0];
		CompilerGeneratedAttribute__ctor_m9DC3E4E2DA76FE93948D44199213E2E924DCBE35(tmp, NULL);
	}
	{
		DebuggerBrowsableAttribute_t2FA4793AD1982F5150E07D26822ED5953CD90F53 * tmp = (DebuggerBrowsableAttribute_t2FA4793AD1982F5150E07D26822ED5953CD90F53 *)cache->attributes[1];
		DebuggerBrowsableAttribute__ctor_mAA8BCC1E418754685F320B14A08AC226E76346E5(tmp, 0LL, NULL);
	}
}
static void Laser_t128A4BF0CB0C0349676F7C0999823F8A05E87ABA_CustomAttributesCacheGenerator_U3CEnabledU3Ek__BackingField(CustomAttributesCache* cache)
{
	{
		CompilerGeneratedAttribute_t39106AB982658D7A94C27DEF3C48DB2F5F7CD75C * tmp = (CompilerGeneratedAttribute_t39106AB982658D7A94C27DEF3C48DB2F5F7CD75C *)cache->attributes[0];
		CompilerGeneratedAttribute__ctor_m9DC3E4E2DA76FE93948D44199213E2E924DCBE35(tmp, NULL);
	}
	{
		DebuggerBrowsableAttribute_t2FA4793AD1982F5150E07D26822ED5953CD90F53 * tmp = (DebuggerBrowsableAttribute_t2FA4793AD1982F5150E07D26822ED5953CD90F53 *)cache->attributes[1];
		DebuggerBrowsableAttribute__ctor_mAA8BCC1E418754685F320B14A08AC226E76346E5(tmp, 0LL, NULL);
	}
}
static void Laser_t128A4BF0CB0C0349676F7C0999823F8A05E87ABA_CustomAttributesCacheGenerator_Laser_get_View_m035A8D00CE81DFD43C34AB6212C88BC267968088(CustomAttributesCache* cache)
{
	{
		CompilerGeneratedAttribute_t39106AB982658D7A94C27DEF3C48DB2F5F7CD75C * tmp = (CompilerGeneratedAttribute_t39106AB982658D7A94C27DEF3C48DB2F5F7CD75C *)cache->attributes[0];
		CompilerGeneratedAttribute__ctor_m9DC3E4E2DA76FE93948D44199213E2E924DCBE35(tmp, NULL);
	}
}
static void Laser_t128A4BF0CB0C0349676F7C0999823F8A05E87ABA_CustomAttributesCacheGenerator_Laser_set_View_m19FE57927E35912CD12D9D45A70281CB17366E0C(CustomAttributesCache* cache)
{
	{
		CompilerGeneratedAttribute_t39106AB982658D7A94C27DEF3C48DB2F5F7CD75C * tmp = (CompilerGeneratedAttribute_t39106AB982658D7A94C27DEF3C48DB2F5F7CD75C *)cache->attributes[0];
		CompilerGeneratedAttribute__ctor_m9DC3E4E2DA76FE93948D44199213E2E924DCBE35(tmp, NULL);
	}
}
static void Laser_t128A4BF0CB0C0349676F7C0999823F8A05E87ABA_CustomAttributesCacheGenerator_Laser_get_LaserColor_m7FE63F0D12FD110700F509268376C7CA53DD74BE(CustomAttributesCache* cache)
{
	{
		CompilerGeneratedAttribute_t39106AB982658D7A94C27DEF3C48DB2F5F7CD75C * tmp = (CompilerGeneratedAttribute_t39106AB982658D7A94C27DEF3C48DB2F5F7CD75C *)cache->attributes[0];
		CompilerGeneratedAttribute__ctor_m9DC3E4E2DA76FE93948D44199213E2E924DCBE35(tmp, NULL);
	}
}
static void Laser_t128A4BF0CB0C0349676F7C0999823F8A05E87ABA_CustomAttributesCacheGenerator_Laser_set_LaserColor_mFD1DB6C778FA9AEF2EE4D78E29241586DFACBB81(CustomAttributesCache* cache)
{
	{
		CompilerGeneratedAttribute_t39106AB982658D7A94C27DEF3C48DB2F5F7CD75C * tmp = (CompilerGeneratedAttribute_t39106AB982658D7A94C27DEF3C48DB2F5F7CD75C *)cache->attributes[0];
		CompilerGeneratedAttribute__ctor_m9DC3E4E2DA76FE93948D44199213E2E924DCBE35(tmp, NULL);
	}
}
static void Laser_t128A4BF0CB0C0349676F7C0999823F8A05E87ABA_CustomAttributesCacheGenerator_Laser_get_Direction_m42A011CF94B55C10A6C12034EB22CCB1A7323174(CustomAttributesCache* cache)
{
	{
		CompilerGeneratedAttribute_t39106AB982658D7A94C27DEF3C48DB2F5F7CD75C * tmp = (CompilerGeneratedAttribute_t39106AB982658D7A94C27DEF3C48DB2F5F7CD75C *)cache->attributes[0];
		CompilerGeneratedAttribute__ctor_m9DC3E4E2DA76FE93948D44199213E2E924DCBE35(tmp, NULL);
	}
}
static void Laser_t128A4BF0CB0C0349676F7C0999823F8A05E87ABA_CustomAttributesCacheGenerator_Laser_set_Direction_m85A24E22D07F4AF441AD3A4B61CDB13D2D578487(CustomAttributesCache* cache)
{
	{
		CompilerGeneratedAttribute_t39106AB982658D7A94C27DEF3C48DB2F5F7CD75C * tmp = (CompilerGeneratedAttribute_t39106AB982658D7A94C27DEF3C48DB2F5F7CD75C *)cache->attributes[0];
		CompilerGeneratedAttribute__ctor_m9DC3E4E2DA76FE93948D44199213E2E924DCBE35(tmp, NULL);
	}
}
static void Laser_t128A4BF0CB0C0349676F7C0999823F8A05E87ABA_CustomAttributesCacheGenerator_Laser_get_Line_mAB930D42ADA9497BA04327B01C4413EE94302487(CustomAttributesCache* cache)
{
	{
		CompilerGeneratedAttribute_t39106AB982658D7A94C27DEF3C48DB2F5F7CD75C * tmp = (CompilerGeneratedAttribute_t39106AB982658D7A94C27DEF3C48DB2F5F7CD75C *)cache->attributes[0];
		CompilerGeneratedAttribute__ctor_m9DC3E4E2DA76FE93948D44199213E2E924DCBE35(tmp, NULL);
	}
}
static void Laser_t128A4BF0CB0C0349676F7C0999823F8A05E87ABA_CustomAttributesCacheGenerator_Laser_set_Line_mF2FB0836B2EB22A2E1661EBA9B97F0507B8895EA(CustomAttributesCache* cache)
{
	{
		CompilerGeneratedAttribute_t39106AB982658D7A94C27DEF3C48DB2F5F7CD75C * tmp = (CompilerGeneratedAttribute_t39106AB982658D7A94C27DEF3C48DB2F5F7CD75C *)cache->attributes[0];
		CompilerGeneratedAttribute__ctor_m9DC3E4E2DA76FE93948D44199213E2E924DCBE35(tmp, NULL);
	}
}
static void Laser_t128A4BF0CB0C0349676F7C0999823F8A05E87ABA_CustomAttributesCacheGenerator_Laser_get_Enabled_m8334B0B7E2D8950FD581058C39080D00B8BFB391(CustomAttributesCache* cache)
{
	{
		CompilerGeneratedAttribute_t39106AB982658D7A94C27DEF3C48DB2F5F7CD75C * tmp = (CompilerGeneratedAttribute_t39106AB982658D7A94C27DEF3C48DB2F5F7CD75C *)cache->attributes[0];
		CompilerGeneratedAttribute__ctor_m9DC3E4E2DA76FE93948D44199213E2E924DCBE35(tmp, NULL);
	}
}
static void Laser_t128A4BF0CB0C0349676F7C0999823F8A05E87ABA_CustomAttributesCacheGenerator_Laser_set_Enabled_mD9BD9F3325D3192BB8F9DD5BD3B2BBE2EEECEEB3(CustomAttributesCache* cache)
{
	{
		CompilerGeneratedAttribute_t39106AB982658D7A94C27DEF3C48DB2F5F7CD75C * tmp = (CompilerGeneratedAttribute_t39106AB982658D7A94C27DEF3C48DB2F5F7CD75C *)cache->attributes[0];
		CompilerGeneratedAttribute__ctor_m9DC3E4E2DA76FE93948D44199213E2E924DCBE35(tmp, NULL);
	}
}
static void RootScript_t93FB85AB1E23DF560E82873C55E126C5D6DCC009_CustomAttributesCacheGenerator_ModuleViews(CustomAttributesCache* cache)
{
	{
		HeaderAttribute_t9B431E6BA0524D46406D9C413D6A71CB5F2DD1AB * tmp = (HeaderAttribute_t9B431E6BA0524D46406D9C413D6A71CB5F2DD1AB *)cache->attributes[0];
		HeaderAttribute__ctor_m601319E0BCE8C44A9E79B2C0ABAAD0FEF46A9F1E(tmp, il2cpp_codegen_string_new_wrapper("\x56\x69\x65\x77\x20\x63\x6F\x6D\x70\x6F\x6E\x65\x6E\x74\x73"), NULL);
	}
}
static void RootScript_t93FB85AB1E23DF560E82873C55E126C5D6DCC009_CustomAttributesCacheGenerator_FloorTilePrefab(CustomAttributesCache* cache)
{
	{
		HeaderAttribute_t9B431E6BA0524D46406D9C413D6A71CB5F2DD1AB * tmp = (HeaderAttribute_t9B431E6BA0524D46406D9C413D6A71CB5F2DD1AB *)cache->attributes[0];
		HeaderAttribute__ctor_m601319E0BCE8C44A9E79B2C0ABAAD0FEF46A9F1E(tmp, il2cpp_codegen_string_new_wrapper("\x53\x74\x61\x67\x65\x20\x53\x65\x74\x74\x69\x6E\x67\x73"), NULL);
	}
	{
		SerializeField_t6B23EE6CC99B21C3EBD946352112832A70E67E25 * tmp = (SerializeField_t6B23EE6CC99B21C3EBD946352112832A70E67E25 *)cache->attributes[1];
		SerializeField__ctor_mDE6A7673BA2C1FAD03CFEC65C6D473CC37889DD3(tmp, NULL);
	}
}
static void RootScript_t93FB85AB1E23DF560E82873C55E126C5D6DCC009_CustomAttributesCacheGenerator_CurrentStage(CustomAttributesCache* cache)
{
	{
		SerializeField_t6B23EE6CC99B21C3EBD946352112832A70E67E25 * tmp = (SerializeField_t6B23EE6CC99B21C3EBD946352112832A70E67E25 *)cache->attributes[0];
		SerializeField__ctor_mDE6A7673BA2C1FAD03CFEC65C6D473CC37889DD3(tmp, NULL);
	}
}
static void RootScript_t93FB85AB1E23DF560E82873C55E126C5D6DCC009_CustomAttributesCacheGenerator_ModulesAmountChanged(CustomAttributesCache* cache)
{
	{
		CompilerGeneratedAttribute_t39106AB982658D7A94C27DEF3C48DB2F5F7CD75C * tmp = (CompilerGeneratedAttribute_t39106AB982658D7A94C27DEF3C48DB2F5F7CD75C *)cache->attributes[0];
		CompilerGeneratedAttribute__ctor_m9DC3E4E2DA76FE93948D44199213E2E924DCBE35(tmp, NULL);
	}
	{
		DebuggerBrowsableAttribute_t2FA4793AD1982F5150E07D26822ED5953CD90F53 * tmp = (DebuggerBrowsableAttribute_t2FA4793AD1982F5150E07D26822ED5953CD90F53 *)cache->attributes[1];
		DebuggerBrowsableAttribute__ctor_mAA8BCC1E418754685F320B14A08AC226E76346E5(tmp, 0LL, NULL);
	}
}
static void RootScript_t93FB85AB1E23DF560E82873C55E126C5D6DCC009_CustomAttributesCacheGenerator_RootScript_add_ModulesAmountChanged_m14995C12E51E98690497E301B0FF6F6C4AEA41D4(CustomAttributesCache* cache)
{
	{
		CompilerGeneratedAttribute_t39106AB982658D7A94C27DEF3C48DB2F5F7CD75C * tmp = (CompilerGeneratedAttribute_t39106AB982658D7A94C27DEF3C48DB2F5F7CD75C *)cache->attributes[0];
		CompilerGeneratedAttribute__ctor_m9DC3E4E2DA76FE93948D44199213E2E924DCBE35(tmp, NULL);
	}
}
static void RootScript_t93FB85AB1E23DF560E82873C55E126C5D6DCC009_CustomAttributesCacheGenerator_RootScript_remove_ModulesAmountChanged_m1558F2D8CC072F351C0F4E8480CE515566531568(CustomAttributesCache* cache)
{
	{
		CompilerGeneratedAttribute_t39106AB982658D7A94C27DEF3C48DB2F5F7CD75C * tmp = (CompilerGeneratedAttribute_t39106AB982658D7A94C27DEF3C48DB2F5F7CD75C *)cache->attributes[0];
		CompilerGeneratedAttribute__ctor_m9DC3E4E2DA76FE93948D44199213E2E924DCBE35(tmp, NULL);
	}
}
static void StageData_tA78E931677EFC2C040DAB3A444AB395BA3562301_CustomAttributesCacheGenerator_ModuleAmounts(CustomAttributesCache* cache)
{
	{
		RangeAttribute_t14A6532D68168764C15E7CF1FDABCD99CB32D0C5 * tmp = (RangeAttribute_t14A6532D68168764C15E7CF1FDABCD99CB32D0C5 *)cache->attributes[0];
		RangeAttribute__ctor_mC74D39A9F20DD2A0D4174F05785ABE4F0DAEF000(tmp, 0.0f, 20.0f, NULL);
	}
	{
		HideInInspector_tDD5B9D3AD8D48C93E23FE6CA3ECDA5589D60CCDA * tmp = (HideInInspector_tDD5B9D3AD8D48C93E23FE6CA3ECDA5589D60CCDA *)cache->attributes[1];
		HideInInspector__ctor_mE2B7FB1D206A74BA583C7812CDB4EBDD83EB66F9(tmp, NULL);
	}
}
static void StageData_tA78E931677EFC2C040DAB3A444AB395BA3562301_CustomAttributesCacheGenerator_Modules(CustomAttributesCache* cache)
{
	{
		HideInInspector_tDD5B9D3AD8D48C93E23FE6CA3ECDA5589D60CCDA * tmp = (HideInInspector_tDD5B9D3AD8D48C93E23FE6CA3ECDA5589D60CCDA *)cache->attributes[0];
		HideInInspector__ctor_mE2B7FB1D206A74BA583C7812CDB4EBDD83EB66F9(tmp, NULL);
	}
}
static void LevelParameters_t50E4ED0E29AE03C24D7F5CD2D421A192D4FAF8B4_CustomAttributesCacheGenerator_GridSize(CustomAttributesCache* cache)
{
	{
		RangeAttribute_t14A6532D68168764C15E7CF1FDABCD99CB32D0C5 * tmp = (RangeAttribute_t14A6532D68168764C15E7CF1FDABCD99CB32D0C5 *)cache->attributes[0];
		RangeAttribute__ctor_mC74D39A9F20DD2A0D4174F05785ABE4F0DAEF000(tmp, 1.0f, 5.0f, NULL);
	}
}
static void LevelParameters_t50E4ED0E29AE03C24D7F5CD2D421A192D4FAF8B4_CustomAttributesCacheGenerator_OffsetSize(CustomAttributesCache* cache)
{
	{
		RangeAttribute_t14A6532D68168764C15E7CF1FDABCD99CB32D0C5 * tmp = (RangeAttribute_t14A6532D68168764C15E7CF1FDABCD99CB32D0C5 *)cache->attributes[0];
		RangeAttribute__ctor_mC74D39A9F20DD2A0D4174F05785ABE4F0DAEF000(tmp, 0.0f, 1.0f, NULL);
	}
}
static void LevelParameters_t50E4ED0E29AE03C24D7F5CD2D421A192D4FAF8B4_CustomAttributesCacheGenerator_Elevations(CustomAttributesCache* cache)
{
	{
		HideInInspector_tDD5B9D3AD8D48C93E23FE6CA3ECDA5589D60CCDA * tmp = (HideInInspector_tDD5B9D3AD8D48C93E23FE6CA3ECDA5589D60CCDA *)cache->attributes[0];
		HideInInspector__ctor_mE2B7FB1D206A74BA583C7812CDB4EBDD83EB66F9(tmp, NULL);
	}
}
static void GameObjectView_t34E778D6D9FCB242216205BBE6122BF00FA37062_CustomAttributesCacheGenerator_ObjectPrefab(CustomAttributesCache* cache)
{
	{
		HeaderAttribute_t9B431E6BA0524D46406D9C413D6A71CB5F2DD1AB * tmp = (HeaderAttribute_t9B431E6BA0524D46406D9C413D6A71CB5F2DD1AB *)cache->attributes[0];
		HeaderAttribute__ctor_m601319E0BCE8C44A9E79B2C0ABAAD0FEF46A9F1E(tmp, il2cpp_codegen_string_new_wrapper("\x4F\x62\x6A\x65\x63\x74\x20\x56\x69\x65\x77\x20\x50\x61\x72\x61\x6D\x65\x74\x65\x72\x73"), NULL);
	}
}
static void GameObjectView_t34E778D6D9FCB242216205BBE6122BF00FA37062_CustomAttributesCacheGenerator_Tile(CustomAttributesCache* cache)
{
	{
		HideInInspector_tDD5B9D3AD8D48C93E23FE6CA3ECDA5589D60CCDA * tmp = (HideInInspector_tDD5B9D3AD8D48C93E23FE6CA3ECDA5589D60CCDA *)cache->attributes[0];
		HideInInspector__ctor_mE2B7FB1D206A74BA583C7812CDB4EBDD83EB66F9(tmp, NULL);
	}
}
static void ModuleObjectView_tBBAD56C2194A8488E762FEE545ED4D14EF512072_CustomAttributesCacheGenerator_Type(CustomAttributesCache* cache)
{
	{
		HeaderAttribute_t9B431E6BA0524D46406D9C413D6A71CB5F2DD1AB * tmp = (HeaderAttribute_t9B431E6BA0524D46406D9C413D6A71CB5F2DD1AB *)cache->attributes[0];
		HeaderAttribute__ctor_m601319E0BCE8C44A9E79B2C0ABAAD0FEF46A9F1E(tmp, il2cpp_codegen_string_new_wrapper("\x4D\x6F\x64\x75\x6C\x65\x20\x4F\x62\x6A\x65\x63\x74\x20\x50\x61\x72\x61\x6D\x65\x74\x65\x72\x73"), NULL);
	}
}
static void ModuleObjectView_tBBAD56C2194A8488E762FEE545ED4D14EF512072_CustomAttributesCacheGenerator_LaserDirection(CustomAttributesCache* cache)
{
	{
		HideInInspector_tDD5B9D3AD8D48C93E23FE6CA3ECDA5589D60CCDA * tmp = (HideInInspector_tDD5B9D3AD8D48C93E23FE6CA3ECDA5589D60CCDA *)cache->attributes[0];
		HideInInspector__ctor_mE2B7FB1D206A74BA583C7812CDB4EBDD83EB66F9(tmp, NULL);
	}
}
static void ModuleObjectView_tBBAD56C2194A8488E762FEE545ED4D14EF512072_CustomAttributesCacheGenerator_InputColors(CustomAttributesCache* cache)
{
	{
		HideInInspector_tDD5B9D3AD8D48C93E23FE6CA3ECDA5589D60CCDA * tmp = (HideInInspector_tDD5B9D3AD8D48C93E23FE6CA3ECDA5589D60CCDA *)cache->attributes[0];
		HideInInspector__ctor_mE2B7FB1D206A74BA583C7812CDB4EBDD83EB66F9(tmp, NULL);
	}
}
static void ModuleObjectView_tBBAD56C2194A8488E762FEE545ED4D14EF512072_CustomAttributesCacheGenerator_TargetColor(CustomAttributesCache* cache)
{
	{
		HideInInspector_tDD5B9D3AD8D48C93E23FE6CA3ECDA5589D60CCDA * tmp = (HideInInspector_tDD5B9D3AD8D48C93E23FE6CA3ECDA5589D60CCDA *)cache->attributes[0];
		HideInInspector__ctor_mE2B7FB1D206A74BA583C7812CDB4EBDD83EB66F9(tmp, NULL);
	}
}
static void TileObjectView_tEB5CDBA1392D86BE7D3FDAFA914C04B23376D4B1_CustomAttributesCacheGenerator_WaveAmplitude(CustomAttributesCache* cache)
{
	{
		RangeAttribute_t14A6532D68168764C15E7CF1FDABCD99CB32D0C5 * tmp = (RangeAttribute_t14A6532D68168764C15E7CF1FDABCD99CB32D0C5 *)cache->attributes[0];
		RangeAttribute__ctor_mC74D39A9F20DD2A0D4174F05785ABE4F0DAEF000(tmp, 0.100000001f, 1.0f, NULL);
	}
}
static void TileObjectView_tEB5CDBA1392D86BE7D3FDAFA914C04B23376D4B1_CustomAttributesCacheGenerator_Frequency(CustomAttributesCache* cache)
{
	{
		RangeAttribute_t14A6532D68168764C15E7CF1FDABCD99CB32D0C5 * tmp = (RangeAttribute_t14A6532D68168764C15E7CF1FDABCD99CB32D0C5 *)cache->attributes[0];
		RangeAttribute__ctor_mC74D39A9F20DD2A0D4174F05785ABE4F0DAEF000(tmp, 0.100000001f, 10.0f, NULL);
	}
}
static void TileObjectView_tEB5CDBA1392D86BE7D3FDAFA914C04B23376D4B1_CustomAttributesCacheGenerator_Elevation(CustomAttributesCache* cache)
{
	{
		RangeAttribute_t14A6532D68168764C15E7CF1FDABCD99CB32D0C5 * tmp = (RangeAttribute_t14A6532D68168764C15E7CF1FDABCD99CB32D0C5 *)cache->attributes[0];
		RangeAttribute__ctor_mC74D39A9F20DD2A0D4174F05785ABE4F0DAEF000(tmp, -32.0f, 32.0f, NULL);
	}
}
static void TileObjectView_tEB5CDBA1392D86BE7D3FDAFA914C04B23376D4B1_CustomAttributesCacheGenerator_U3CCoordinatesU3Ek__BackingField(CustomAttributesCache* cache)
{
	{
		CompilerGeneratedAttribute_t39106AB982658D7A94C27DEF3C48DB2F5F7CD75C * tmp = (CompilerGeneratedAttribute_t39106AB982658D7A94C27DEF3C48DB2F5F7CD75C *)cache->attributes[0];
		CompilerGeneratedAttribute__ctor_m9DC3E4E2DA76FE93948D44199213E2E924DCBE35(tmp, NULL);
	}
	{
		DebuggerBrowsableAttribute_t2FA4793AD1982F5150E07D26822ED5953CD90F53 * tmp = (DebuggerBrowsableAttribute_t2FA4793AD1982F5150E07D26822ED5953CD90F53 *)cache->attributes[1];
		DebuggerBrowsableAttribute__ctor_mAA8BCC1E418754685F320B14A08AC226E76346E5(tmp, 0LL, NULL);
	}
}
static void TileObjectView_tEB5CDBA1392D86BE7D3FDAFA914C04B23376D4B1_CustomAttributesCacheGenerator_TileObjectView_get_Coordinates_m9C35BD5E8F0C943B9BFFC95DAF7CCC29440456E5(CustomAttributesCache* cache)
{
	{
		CompilerGeneratedAttribute_t39106AB982658D7A94C27DEF3C48DB2F5F7CD75C * tmp = (CompilerGeneratedAttribute_t39106AB982658D7A94C27DEF3C48DB2F5F7CD75C *)cache->attributes[0];
		CompilerGeneratedAttribute__ctor_m9DC3E4E2DA76FE93948D44199213E2E924DCBE35(tmp, NULL);
	}
}
static void TileObjectView_tEB5CDBA1392D86BE7D3FDAFA914C04B23376D4B1_CustomAttributesCacheGenerator_TileObjectView_set_Coordinates_m12D0221151BE04343B2EDE126652B6A3187207DD(CustomAttributesCache* cache)
{
	{
		CompilerGeneratedAttribute_t39106AB982658D7A94C27DEF3C48DB2F5F7CD75C * tmp = (CompilerGeneratedAttribute_t39106AB982658D7A94C27DEF3C48DB2F5F7CD75C *)cache->attributes[0];
		CompilerGeneratedAttribute__ctor_m9DC3E4E2DA76FE93948D44199213E2E924DCBE35(tmp, NULL);
	}
}
IL2CPP_EXTERN_C const CustomAttributesCacheGenerator g_AssemblyU2DCSharp_AttributeGenerators[];
const CustomAttributesCacheGenerator g_AssemblyU2DCSharp_AttributeGenerators[63] = 
{
	CameraController_tCFCE51ADE50A46097682FD3E2CEA53100D84E7E0_CustomAttributesCacheGenerator_U3CMainCameraU3Ek__BackingField,
	GoalController_t4AFE584FC90F1D61939DAEEA167B3C902D469493_CustomAttributesCacheGenerator_U3CinstanceU3Ek__BackingField,
	GoalController_t4AFE584FC90F1D61939DAEEA167B3C902D469493_CustomAttributesCacheGenerator_U3CGoalReachedU3Ek__BackingField,
	GoalController_t4AFE584FC90F1D61939DAEEA167B3C902D469493_CustomAttributesCacheGenerator_AbsorberColorChanged,
	InputController_tE5796D3B3202F143B79AC438A06019484963D990_CustomAttributesCacheGenerator_U3CinstanceU3Ek__BackingField,
	InputController_tE5796D3B3202F143B79AC438A06019484963D990_CustomAttributesCacheGenerator_TouchMove,
	LevelController_tE4C446AC0B9C5216612A4CD60E1C878E8329A430_CustomAttributesCacheGenerator_U3CTilesU3Ek__BackingField,
	SaveController_tFB7D347083FDE3C8BCB09893AE1DAF9766740B15_CustomAttributesCacheGenerator_U3CinstanceU3Ek__BackingField,
	Laser_t128A4BF0CB0C0349676F7C0999823F8A05E87ABA_CustomAttributesCacheGenerator_U3CViewU3Ek__BackingField,
	Laser_t128A4BF0CB0C0349676F7C0999823F8A05E87ABA_CustomAttributesCacheGenerator_U3CLaserColorU3Ek__BackingField,
	Laser_t128A4BF0CB0C0349676F7C0999823F8A05E87ABA_CustomAttributesCacheGenerator_U3CDirectionU3Ek__BackingField,
	Laser_t128A4BF0CB0C0349676F7C0999823F8A05E87ABA_CustomAttributesCacheGenerator_U3CLineU3Ek__BackingField,
	Laser_t128A4BF0CB0C0349676F7C0999823F8A05E87ABA_CustomAttributesCacheGenerator_U3CEnabledU3Ek__BackingField,
	RootScript_t93FB85AB1E23DF560E82873C55E126C5D6DCC009_CustomAttributesCacheGenerator_ModuleViews,
	RootScript_t93FB85AB1E23DF560E82873C55E126C5D6DCC009_CustomAttributesCacheGenerator_FloorTilePrefab,
	RootScript_t93FB85AB1E23DF560E82873C55E126C5D6DCC009_CustomAttributesCacheGenerator_CurrentStage,
	RootScript_t93FB85AB1E23DF560E82873C55E126C5D6DCC009_CustomAttributesCacheGenerator_ModulesAmountChanged,
	StageData_tA78E931677EFC2C040DAB3A444AB395BA3562301_CustomAttributesCacheGenerator_ModuleAmounts,
	StageData_tA78E931677EFC2C040DAB3A444AB395BA3562301_CustomAttributesCacheGenerator_Modules,
	LevelParameters_t50E4ED0E29AE03C24D7F5CD2D421A192D4FAF8B4_CustomAttributesCacheGenerator_GridSize,
	LevelParameters_t50E4ED0E29AE03C24D7F5CD2D421A192D4FAF8B4_CustomAttributesCacheGenerator_OffsetSize,
	LevelParameters_t50E4ED0E29AE03C24D7F5CD2D421A192D4FAF8B4_CustomAttributesCacheGenerator_Elevations,
	GameObjectView_t34E778D6D9FCB242216205BBE6122BF00FA37062_CustomAttributesCacheGenerator_ObjectPrefab,
	GameObjectView_t34E778D6D9FCB242216205BBE6122BF00FA37062_CustomAttributesCacheGenerator_Tile,
	ModuleObjectView_tBBAD56C2194A8488E762FEE545ED4D14EF512072_CustomAttributesCacheGenerator_Type,
	ModuleObjectView_tBBAD56C2194A8488E762FEE545ED4D14EF512072_CustomAttributesCacheGenerator_LaserDirection,
	ModuleObjectView_tBBAD56C2194A8488E762FEE545ED4D14EF512072_CustomAttributesCacheGenerator_InputColors,
	ModuleObjectView_tBBAD56C2194A8488E762FEE545ED4D14EF512072_CustomAttributesCacheGenerator_TargetColor,
	TileObjectView_tEB5CDBA1392D86BE7D3FDAFA914C04B23376D4B1_CustomAttributesCacheGenerator_WaveAmplitude,
	TileObjectView_tEB5CDBA1392D86BE7D3FDAFA914C04B23376D4B1_CustomAttributesCacheGenerator_Frequency,
	TileObjectView_tEB5CDBA1392D86BE7D3FDAFA914C04B23376D4B1_CustomAttributesCacheGenerator_Elevation,
	TileObjectView_tEB5CDBA1392D86BE7D3FDAFA914C04B23376D4B1_CustomAttributesCacheGenerator_U3CCoordinatesU3Ek__BackingField,
	CameraController_tCFCE51ADE50A46097682FD3E2CEA53100D84E7E0_CustomAttributesCacheGenerator_CameraController_get_MainCamera_m4891C6270550DC5362E9C5FDF2628AF6C755B22B,
	CameraController_tCFCE51ADE50A46097682FD3E2CEA53100D84E7E0_CustomAttributesCacheGenerator_CameraController_set_MainCamera_m8420EBB666CB7556D4E7C84E42FAA3064EBDC990,
	GoalController_t4AFE584FC90F1D61939DAEEA167B3C902D469493_CustomAttributesCacheGenerator_GoalController_get_instance_m2B44E6A94369DD896C6BFA851538621A41A9D806,
	GoalController_t4AFE584FC90F1D61939DAEEA167B3C902D469493_CustomAttributesCacheGenerator_GoalController_set_instance_mB6591465AA7E953E9140D7814805D071C3EEDB1B,
	GoalController_t4AFE584FC90F1D61939DAEEA167B3C902D469493_CustomAttributesCacheGenerator_GoalController_get_GoalReached_mEA91245C02041A7EA7C8B2FAC9115F952E0990EF,
	GoalController_t4AFE584FC90F1D61939DAEEA167B3C902D469493_CustomAttributesCacheGenerator_GoalController_set_GoalReached_mAEFAFD2EC61C7BA247AE1505338FAA8C9E65318E,
	GoalController_t4AFE584FC90F1D61939DAEEA167B3C902D469493_CustomAttributesCacheGenerator_GoalController_add_AbsorberColorChanged_m619AE242C05CB7CDA4CA9085346622C4B737948A,
	GoalController_t4AFE584FC90F1D61939DAEEA167B3C902D469493_CustomAttributesCacheGenerator_GoalController_remove_AbsorberColorChanged_mD306F88EECAA52A28EBD761F310D633C62C36723,
	InputController_tE5796D3B3202F143B79AC438A06019484963D990_CustomAttributesCacheGenerator_InputController_get_instance_m49A4333C4704C9D9AB1863EA780CFE3858827B7C,
	InputController_tE5796D3B3202F143B79AC438A06019484963D990_CustomAttributesCacheGenerator_InputController_set_instance_mC1A3D0D7E301EC5ECA681E7BA183759A10D99576,
	InputController_tE5796D3B3202F143B79AC438A06019484963D990_CustomAttributesCacheGenerator_InputController_add_TouchMove_m5F81F5F08739552E0F6B041734665211CE8293B6,
	InputController_tE5796D3B3202F143B79AC438A06019484963D990_CustomAttributesCacheGenerator_InputController_remove_TouchMove_m993F68CEE893436D9FE952682F02FDCC129B66A3,
	LevelController_tE4C446AC0B9C5216612A4CD60E1C878E8329A430_CustomAttributesCacheGenerator_LevelController_get_Tiles_mAFC52CA935ACD0055263E3BF94D75A8CB0ADC89D,
	LevelController_tE4C446AC0B9C5216612A4CD60E1C878E8329A430_CustomAttributesCacheGenerator_LevelController_set_Tiles_mB8C60D16F190CBE8F3C3070DF776C295CEAFADBD,
	SaveController_tFB7D347083FDE3C8BCB09893AE1DAF9766740B15_CustomAttributesCacheGenerator_SaveController_get_instance_mA09584B45DCD65F69DB02F9F7686F0BE03DD61D0,
	SaveController_tFB7D347083FDE3C8BCB09893AE1DAF9766740B15_CustomAttributesCacheGenerator_SaveController_set_instance_m66389D2DC0D57241662D987E01D3C22247641259,
	Laser_t128A4BF0CB0C0349676F7C0999823F8A05E87ABA_CustomAttributesCacheGenerator_Laser_get_View_m035A8D00CE81DFD43C34AB6212C88BC267968088,
	Laser_t128A4BF0CB0C0349676F7C0999823F8A05E87ABA_CustomAttributesCacheGenerator_Laser_set_View_m19FE57927E35912CD12D9D45A70281CB17366E0C,
	Laser_t128A4BF0CB0C0349676F7C0999823F8A05E87ABA_CustomAttributesCacheGenerator_Laser_get_LaserColor_m7FE63F0D12FD110700F509268376C7CA53DD74BE,
	Laser_t128A4BF0CB0C0349676F7C0999823F8A05E87ABA_CustomAttributesCacheGenerator_Laser_set_LaserColor_mFD1DB6C778FA9AEF2EE4D78E29241586DFACBB81,
	Laser_t128A4BF0CB0C0349676F7C0999823F8A05E87ABA_CustomAttributesCacheGenerator_Laser_get_Direction_m42A011CF94B55C10A6C12034EB22CCB1A7323174,
	Laser_t128A4BF0CB0C0349676F7C0999823F8A05E87ABA_CustomAttributesCacheGenerator_Laser_set_Direction_m85A24E22D07F4AF441AD3A4B61CDB13D2D578487,
	Laser_t128A4BF0CB0C0349676F7C0999823F8A05E87ABA_CustomAttributesCacheGenerator_Laser_get_Line_mAB930D42ADA9497BA04327B01C4413EE94302487,
	Laser_t128A4BF0CB0C0349676F7C0999823F8A05E87ABA_CustomAttributesCacheGenerator_Laser_set_Line_mF2FB0836B2EB22A2E1661EBA9B97F0507B8895EA,
	Laser_t128A4BF0CB0C0349676F7C0999823F8A05E87ABA_CustomAttributesCacheGenerator_Laser_get_Enabled_m8334B0B7E2D8950FD581058C39080D00B8BFB391,
	Laser_t128A4BF0CB0C0349676F7C0999823F8A05E87ABA_CustomAttributesCacheGenerator_Laser_set_Enabled_mD9BD9F3325D3192BB8F9DD5BD3B2BBE2EEECEEB3,
	RootScript_t93FB85AB1E23DF560E82873C55E126C5D6DCC009_CustomAttributesCacheGenerator_RootScript_add_ModulesAmountChanged_m14995C12E51E98690497E301B0FF6F6C4AEA41D4,
	RootScript_t93FB85AB1E23DF560E82873C55E126C5D6DCC009_CustomAttributesCacheGenerator_RootScript_remove_ModulesAmountChanged_m1558F2D8CC072F351C0F4E8480CE515566531568,
	TileObjectView_tEB5CDBA1392D86BE7D3FDAFA914C04B23376D4B1_CustomAttributesCacheGenerator_TileObjectView_get_Coordinates_m9C35BD5E8F0C943B9BFFC95DAF7CCC29440456E5,
	TileObjectView_tEB5CDBA1392D86BE7D3FDAFA914C04B23376D4B1_CustomAttributesCacheGenerator_TileObjectView_set_Coordinates_m12D0221151BE04343B2EDE126652B6A3187207DD,
	AssemblyU2DCSharp_CustomAttributesCacheGenerator,
};
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void RuntimeCompatibilityAttribute_set_WrapNonExceptionThrows_m8562196F90F3EBCEC23B5708EE0332842883C490_inline (RuntimeCompatibilityAttribute_tFF99AB2963098F9CBCD47A20D9FD3D51C17C1C80 * __this, bool ___value0, const RuntimeMethod* method)
{
	{
		bool L_0 = ___value0;
		__this->set_m_wrapNonExceptionThrows_0(L_0);
		return;
	}
}
