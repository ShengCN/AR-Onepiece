#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

// System.Collections.Generic.List`1<ExitGames.Client.Photon.NCommand>
struct List_1_t1502735431;
// System.Collections.Generic.Queue`1<ExitGames.Client.Photon.NCommand>
struct Queue_1_t1953271134;
// System.Byte[]
struct ByteU5BU5D_t3397334013;
// ExitGames.Client.Photon.EnetChannel[]
struct EnetChannelU5BU5D_t579585926;
// System.Collections.Generic.Queue`1<System.Int32>
struct Queue_1_t1891534283;

#include "Photon3Unity3D_ExitGames_Client_Photon_PeerBase822653733.h"

#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// ExitGames.Client.Photon.EnetPeer
struct  EnetPeer_t2873400856  : public PeerBase_t822653733
{
public:
	// System.Collections.Generic.List`1<ExitGames.Client.Photon.NCommand> ExitGames.Client.Photon.EnetPeer::sentReliableCommands
	List_1_t1502735431 * ___sentReliableCommands_56;
	// System.Collections.Generic.Queue`1<ExitGames.Client.Photon.NCommand> ExitGames.Client.Photon.EnetPeer::outgoingAcknowledgementsList
	Queue_1_t1953271134 * ___outgoingAcknowledgementsList_57;
	// System.Int32 ExitGames.Client.Photon.EnetPeer::windowSize
	int32_t ___windowSize_58;
	// System.Byte ExitGames.Client.Photon.EnetPeer::udpCommandCount
	uint8_t ___udpCommandCount_59;
	// System.Byte[] ExitGames.Client.Photon.EnetPeer::udpBuffer
	ByteU5BU5D_t3397334013* ___udpBuffer_60;
	// System.Int32 ExitGames.Client.Photon.EnetPeer::udpBufferIndex
	int32_t ___udpBufferIndex_61;
	// System.Int32 ExitGames.Client.Photon.EnetPeer::udpBufferLength
	int32_t ___udpBufferLength_62;
	// System.Byte[] ExitGames.Client.Photon.EnetPeer::bufferForEncryption
	ByteU5BU5D_t3397334013* ___bufferForEncryption_63;
	// System.Int32 ExitGames.Client.Photon.EnetPeer::challenge
	int32_t ___challenge_64;
	// System.Int32 ExitGames.Client.Photon.EnetPeer::reliableCommandsRepeated
	int32_t ___reliableCommandsRepeated_65;
	// System.Int32 ExitGames.Client.Photon.EnetPeer::reliableCommandsSent
	int32_t ___reliableCommandsSent_66;
	// System.Int32 ExitGames.Client.Photon.EnetPeer::serverSentTime
	int32_t ___serverSentTime_67;
	// System.Boolean ExitGames.Client.Photon.EnetPeer::datagramEncryptedConnection
	bool ___datagramEncryptedConnection_70;
	// ExitGames.Client.Photon.EnetChannel[] ExitGames.Client.Photon.EnetPeer::channelArray
	EnetChannelU5BU5D_t579585926* ___channelArray_71;
	// System.Collections.Generic.Queue`1<System.Int32> ExitGames.Client.Photon.EnetPeer::commandsToRemove
	Queue_1_t1891534283 * ___commandsToRemove_72;
	// System.Collections.Generic.Queue`1<ExitGames.Client.Photon.NCommand> ExitGames.Client.Photon.EnetPeer::commandsToResend
	Queue_1_t1953271134 * ___commandsToResend_73;

public:
	inline static int32_t get_offset_of_sentReliableCommands_56() { return static_cast<int32_t>(offsetof(EnetPeer_t2873400856, ___sentReliableCommands_56)); }
	inline List_1_t1502735431 * get_sentReliableCommands_56() const { return ___sentReliableCommands_56; }
	inline List_1_t1502735431 ** get_address_of_sentReliableCommands_56() { return &___sentReliableCommands_56; }
	inline void set_sentReliableCommands_56(List_1_t1502735431 * value)
	{
		___sentReliableCommands_56 = value;
		Il2CppCodeGenWriteBarrier(&___sentReliableCommands_56, value);
	}

	inline static int32_t get_offset_of_outgoingAcknowledgementsList_57() { return static_cast<int32_t>(offsetof(EnetPeer_t2873400856, ___outgoingAcknowledgementsList_57)); }
	inline Queue_1_t1953271134 * get_outgoingAcknowledgementsList_57() const { return ___outgoingAcknowledgementsList_57; }
	inline Queue_1_t1953271134 ** get_address_of_outgoingAcknowledgementsList_57() { return &___outgoingAcknowledgementsList_57; }
	inline void set_outgoingAcknowledgementsList_57(Queue_1_t1953271134 * value)
	{
		___outgoingAcknowledgementsList_57 = value;
		Il2CppCodeGenWriteBarrier(&___outgoingAcknowledgementsList_57, value);
	}

	inline static int32_t get_offset_of_windowSize_58() { return static_cast<int32_t>(offsetof(EnetPeer_t2873400856, ___windowSize_58)); }
	inline int32_t get_windowSize_58() const { return ___windowSize_58; }
	inline int32_t* get_address_of_windowSize_58() { return &___windowSize_58; }
	inline void set_windowSize_58(int32_t value)
	{
		___windowSize_58 = value;
	}

	inline static int32_t get_offset_of_udpCommandCount_59() { return static_cast<int32_t>(offsetof(EnetPeer_t2873400856, ___udpCommandCount_59)); }
	inline uint8_t get_udpCommandCount_59() const { return ___udpCommandCount_59; }
	inline uint8_t* get_address_of_udpCommandCount_59() { return &___udpCommandCount_59; }
	inline void set_udpCommandCount_59(uint8_t value)
	{
		___udpCommandCount_59 = value;
	}

	inline static int32_t get_offset_of_udpBuffer_60() { return static_cast<int32_t>(offsetof(EnetPeer_t2873400856, ___udpBuffer_60)); }
	inline ByteU5BU5D_t3397334013* get_udpBuffer_60() const { return ___udpBuffer_60; }
	inline ByteU5BU5D_t3397334013** get_address_of_udpBuffer_60() { return &___udpBuffer_60; }
	inline void set_udpBuffer_60(ByteU5BU5D_t3397334013* value)
	{
		___udpBuffer_60 = value;
		Il2CppCodeGenWriteBarrier(&___udpBuffer_60, value);
	}

	inline static int32_t get_offset_of_udpBufferIndex_61() { return static_cast<int32_t>(offsetof(EnetPeer_t2873400856, ___udpBufferIndex_61)); }
	inline int32_t get_udpBufferIndex_61() const { return ___udpBufferIndex_61; }
	inline int32_t* get_address_of_udpBufferIndex_61() { return &___udpBufferIndex_61; }
	inline void set_udpBufferIndex_61(int32_t value)
	{
		___udpBufferIndex_61 = value;
	}

	inline static int32_t get_offset_of_udpBufferLength_62() { return static_cast<int32_t>(offsetof(EnetPeer_t2873400856, ___udpBufferLength_62)); }
	inline int32_t get_udpBufferLength_62() const { return ___udpBufferLength_62; }
	inline int32_t* get_address_of_udpBufferLength_62() { return &___udpBufferLength_62; }
	inline void set_udpBufferLength_62(int32_t value)
	{
		___udpBufferLength_62 = value;
	}

	inline static int32_t get_offset_of_bufferForEncryption_63() { return static_cast<int32_t>(offsetof(EnetPeer_t2873400856, ___bufferForEncryption_63)); }
	inline ByteU5BU5D_t3397334013* get_bufferForEncryption_63() const { return ___bufferForEncryption_63; }
	inline ByteU5BU5D_t3397334013** get_address_of_bufferForEncryption_63() { return &___bufferForEncryption_63; }
	inline void set_bufferForEncryption_63(ByteU5BU5D_t3397334013* value)
	{
		___bufferForEncryption_63 = value;
		Il2CppCodeGenWriteBarrier(&___bufferForEncryption_63, value);
	}

	inline static int32_t get_offset_of_challenge_64() { return static_cast<int32_t>(offsetof(EnetPeer_t2873400856, ___challenge_64)); }
	inline int32_t get_challenge_64() const { return ___challenge_64; }
	inline int32_t* get_address_of_challenge_64() { return &___challenge_64; }
	inline void set_challenge_64(int32_t value)
	{
		___challenge_64 = value;
	}

	inline static int32_t get_offset_of_reliableCommandsRepeated_65() { return static_cast<int32_t>(offsetof(EnetPeer_t2873400856, ___reliableCommandsRepeated_65)); }
	inline int32_t get_reliableCommandsRepeated_65() const { return ___reliableCommandsRepeated_65; }
	inline int32_t* get_address_of_reliableCommandsRepeated_65() { return &___reliableCommandsRepeated_65; }
	inline void set_reliableCommandsRepeated_65(int32_t value)
	{
		___reliableCommandsRepeated_65 = value;
	}

	inline static int32_t get_offset_of_reliableCommandsSent_66() { return static_cast<int32_t>(offsetof(EnetPeer_t2873400856, ___reliableCommandsSent_66)); }
	inline int32_t get_reliableCommandsSent_66() const { return ___reliableCommandsSent_66; }
	inline int32_t* get_address_of_reliableCommandsSent_66() { return &___reliableCommandsSent_66; }
	inline void set_reliableCommandsSent_66(int32_t value)
	{
		___reliableCommandsSent_66 = value;
	}

	inline static int32_t get_offset_of_serverSentTime_67() { return static_cast<int32_t>(offsetof(EnetPeer_t2873400856, ___serverSentTime_67)); }
	inline int32_t get_serverSentTime_67() const { return ___serverSentTime_67; }
	inline int32_t* get_address_of_serverSentTime_67() { return &___serverSentTime_67; }
	inline void set_serverSentTime_67(int32_t value)
	{
		___serverSentTime_67 = value;
	}

	inline static int32_t get_offset_of_datagramEncryptedConnection_70() { return static_cast<int32_t>(offsetof(EnetPeer_t2873400856, ___datagramEncryptedConnection_70)); }
	inline bool get_datagramEncryptedConnection_70() const { return ___datagramEncryptedConnection_70; }
	inline bool* get_address_of_datagramEncryptedConnection_70() { return &___datagramEncryptedConnection_70; }
	inline void set_datagramEncryptedConnection_70(bool value)
	{
		___datagramEncryptedConnection_70 = value;
	}

	inline static int32_t get_offset_of_channelArray_71() { return static_cast<int32_t>(offsetof(EnetPeer_t2873400856, ___channelArray_71)); }
	inline EnetChannelU5BU5D_t579585926* get_channelArray_71() const { return ___channelArray_71; }
	inline EnetChannelU5BU5D_t579585926** get_address_of_channelArray_71() { return &___channelArray_71; }
	inline void set_channelArray_71(EnetChannelU5BU5D_t579585926* value)
	{
		___channelArray_71 = value;
		Il2CppCodeGenWriteBarrier(&___channelArray_71, value);
	}

	inline static int32_t get_offset_of_commandsToRemove_72() { return static_cast<int32_t>(offsetof(EnetPeer_t2873400856, ___commandsToRemove_72)); }
	inline Queue_1_t1891534283 * get_commandsToRemove_72() const { return ___commandsToRemove_72; }
	inline Queue_1_t1891534283 ** get_address_of_commandsToRemove_72() { return &___commandsToRemove_72; }
	inline void set_commandsToRemove_72(Queue_1_t1891534283 * value)
	{
		___commandsToRemove_72 = value;
		Il2CppCodeGenWriteBarrier(&___commandsToRemove_72, value);
	}

	inline static int32_t get_offset_of_commandsToResend_73() { return static_cast<int32_t>(offsetof(EnetPeer_t2873400856, ___commandsToResend_73)); }
	inline Queue_1_t1953271134 * get_commandsToResend_73() const { return ___commandsToResend_73; }
	inline Queue_1_t1953271134 ** get_address_of_commandsToResend_73() { return &___commandsToResend_73; }
	inline void set_commandsToResend_73(Queue_1_t1953271134 * value)
	{
		___commandsToResend_73 = value;
		Il2CppCodeGenWriteBarrier(&___commandsToResend_73, value);
	}
};

struct EnetPeer_t2873400856_StaticFields
{
public:
	// System.Int32 ExitGames.Client.Photon.EnetPeer::HMAC_SIZE
	int32_t ___HMAC_SIZE_53;
	// System.Int32 ExitGames.Client.Photon.EnetPeer::BLOCK_SIZE
	int32_t ___BLOCK_SIZE_54;
	// System.Int32 ExitGames.Client.Photon.EnetPeer::IV_SIZE
	int32_t ___IV_SIZE_55;
	// System.Byte[] ExitGames.Client.Photon.EnetPeer::udpHeader0xF3
	ByteU5BU5D_t3397334013* ___udpHeader0xF3_68;
	// System.Byte[] ExitGames.Client.Photon.EnetPeer::messageHeader
	ByteU5BU5D_t3397334013* ___messageHeader_69;

public:
	inline static int32_t get_offset_of_HMAC_SIZE_53() { return static_cast<int32_t>(offsetof(EnetPeer_t2873400856_StaticFields, ___HMAC_SIZE_53)); }
	inline int32_t get_HMAC_SIZE_53() const { return ___HMAC_SIZE_53; }
	inline int32_t* get_address_of_HMAC_SIZE_53() { return &___HMAC_SIZE_53; }
	inline void set_HMAC_SIZE_53(int32_t value)
	{
		___HMAC_SIZE_53 = value;
	}

	inline static int32_t get_offset_of_BLOCK_SIZE_54() { return static_cast<int32_t>(offsetof(EnetPeer_t2873400856_StaticFields, ___BLOCK_SIZE_54)); }
	inline int32_t get_BLOCK_SIZE_54() const { return ___BLOCK_SIZE_54; }
	inline int32_t* get_address_of_BLOCK_SIZE_54() { return &___BLOCK_SIZE_54; }
	inline void set_BLOCK_SIZE_54(int32_t value)
	{
		___BLOCK_SIZE_54 = value;
	}

	inline static int32_t get_offset_of_IV_SIZE_55() { return static_cast<int32_t>(offsetof(EnetPeer_t2873400856_StaticFields, ___IV_SIZE_55)); }
	inline int32_t get_IV_SIZE_55() const { return ___IV_SIZE_55; }
	inline int32_t* get_address_of_IV_SIZE_55() { return &___IV_SIZE_55; }
	inline void set_IV_SIZE_55(int32_t value)
	{
		___IV_SIZE_55 = value;
	}

	inline static int32_t get_offset_of_udpHeader0xF3_68() { return static_cast<int32_t>(offsetof(EnetPeer_t2873400856_StaticFields, ___udpHeader0xF3_68)); }
	inline ByteU5BU5D_t3397334013* get_udpHeader0xF3_68() const { return ___udpHeader0xF3_68; }
	inline ByteU5BU5D_t3397334013** get_address_of_udpHeader0xF3_68() { return &___udpHeader0xF3_68; }
	inline void set_udpHeader0xF3_68(ByteU5BU5D_t3397334013* value)
	{
		___udpHeader0xF3_68 = value;
		Il2CppCodeGenWriteBarrier(&___udpHeader0xF3_68, value);
	}

	inline static int32_t get_offset_of_messageHeader_69() { return static_cast<int32_t>(offsetof(EnetPeer_t2873400856_StaticFields, ___messageHeader_69)); }
	inline ByteU5BU5D_t3397334013* get_messageHeader_69() const { return ___messageHeader_69; }
	inline ByteU5BU5D_t3397334013** get_address_of_messageHeader_69() { return &___messageHeader_69; }
	inline void set_messageHeader_69(ByteU5BU5D_t3397334013* value)
	{
		___messageHeader_69 = value;
		Il2CppCodeGenWriteBarrier(&___messageHeader_69, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
