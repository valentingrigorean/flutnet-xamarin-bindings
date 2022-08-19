using System;
using CoreGraphics;
using CoreVideo;
using Foundation;
using ObjCRuntime;
using UIKit;
using UserNotifications;

namespace Flutnet.Interop
{
	


    interface IFlutterMethodCodec
    {
    }

    interface IFlutterMessageCodec
    {
    }

    interface IFlutterTexture
    {
    }

    interface IFlutterApplicationLifeCycleDelegate
    {
    }

    interface IFlutterPluginRegistry
    {
    }

    interface IFlutterPluginRegistrar
    {
    }

    interface IFlutterAppLifeCycleProvider
    {
    }

    interface IFlutterTextureRegistry
    {
    }

	interface IFlutterBinaryMessenger
    {
    }

	interface IFlutterPlugin
    {
    }

	interface IFlutterPlatformViewFactory
    {
    }

	interface IFlutterPlatformView
    {
    }

	interface IFlutterStreamHandler
    {
    }

    interface IFlutterTaskQueue
    {
    }


    // typedef void (^FlutterBinaryReply)(NSData * _Nullable);
    delegate void FlutterBinaryReply([NullAllowed] NSData arg0);

    // typedef void (^FlutterBinaryMessageHandler)(NSData * _Nullable, FlutterBinaryReply _Nonnull);
    delegate void FlutterBinaryMessageHandler([NullAllowed] NSData arg0, [CCallback] FlutterBinaryReply arg1);

    [Static]
    partial interface Constants
    {
        // extern const NSNotificationName _Nonnull FlutterSemanticsUpdateNotification;
        [Field("FlutterSemanticsUpdateNotification", "__Internal")]
        NSString FlutterSemanticsUpdateNotification { get; }

        // extern const NSObject * _Nonnull FlutterMethodNotImplemented;
        [Field("FlutterMethodNotImplemented", "__Internal")]
        IntPtr FlutterMethodNotImplemented { get; }

        // extern const NSObject * _Nonnull FlutterEndOfEventStream;
        [Field("FlutterEndOfEventStream", "__Internal")]
        IntPtr FlutterEndOfEventStream { get; }

        // extern NSString *const _Nonnull FlutterDefaultDartEntrypoint;
        [Field("FlutterDefaultDartEntrypoint", "__Internal")]
        NSString FlutterDefaultDartEntrypoint { get; }

        // extern NSString *const _Nonnull FlutterDefaultInitialRoute;
        [Field("FlutterDefaultInitialRoute", "__Internal")]
        NSString FlutterDefaultInitialRoute { get; }
    }


    delegate void NSDispatchHandlerT();

    [Protocol]
    interface FlutterTaskQueue
    {
        //- (void) dispatch:(dispatch_block_t) block;
        [Export("dispatch:")]
        void Dispatch(NSDispatchHandlerT block);
    }



    // @protocol FlutterBinaryMessenger <NSObject>
    /*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/
    [Protocol]
    interface FlutterBinaryMessenger 
    {
		// @optional -(NSObject<FlutterTaskQueue> * _Nonnull)makeBackgroundTaskQueue;
		[Export("makeBackgroundTaskQueue")]
		IFlutterTaskQueue MakeBackgroundTaskQueue();

        // @optional -(FlutterBinaryMessengerConnection)setMessageHandlerOnChannel:(NSString * _Nonnull)channel binaryMessageHandler:(FlutterBinaryMessageHandler _Nullable)handler taskQueue:(NSObject<FlutterTaskQueue> * _Nullable)taskQueue;
        [Export("setMessageHandlerOnChannel:binaryMessageHandler:taskQueue:")]
        long SetMessageHandlerOnChannel(string channel, [NullAllowed] FlutterBinaryMessageHandler handler, [NullAllowed] IFlutterTaskQueue taskQueue);

        // @required -(void)sendOnChannel:(NSString * _Nonnull)channel message:(NSData * _Nullable)message;
        [Abstract]
        [Export("sendOnChannel:message:")]
        void SendOnChannel(string channel, [NullAllowed] NSData message);

        // @required -(void)sendOnChannel:(NSString * _Nonnull)channel message:(NSData * _Nullable)message binaryReply:(FlutterBinaryReply _Nullable)callback;
        [Abstract]
        [Export("sendOnChannel:message:binaryReply:")]
        void SendOnChannel(string channel, [NullAllowed] NSData message, [NullAllowed] FlutterBinaryReply callback);

        // @required -(FlutterBinaryMessengerConnection)setMessageHandlerOnChannel:(NSString * _Nonnull)channel binaryMessageHandler:(FlutterBinaryMessageHandler _Nullable)handler;
        [Abstract]
        [Export("setMessageHandlerOnChannel:binaryMessageHandler:")]
        long SetMessageHandlerOnChannel(string channel, [NullAllowed] FlutterBinaryMessageHandler handler);

        // @required -(void)cleanUpConnection:(FlutterBinaryMessengerConnection)connection;
        [Abstract]
        [Export("cleanUpConnection:")]
        void CleanUpConnection(long connection);
    }

    // @protocol FlutterMessageCodec
    /*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/
    [Protocol]
	interface FlutterMessageCodec
	{
		// @required +(instancetype _Nonnull)sharedInstance;
		[Static, Abstract]
		[Export ("sharedInstance")]
		IFlutterMessageCodec SharedInstance ();

		// @required -(NSData * _Nullable)encode:(id _Nullable)message;
		[Abstract]
		[Export ("encode:")]
		[return: NullAllowed]
		NSData Encode ([NullAllowed] NSObject message);

		// @required -(id _Nullable)decode:(NSData * _Nullable)message;
		[Abstract]
		[Export ("decode:")]
		[return: NullAllowed]
		NSObject Decode ([NullAllowed] NSData message);
	}

	// @interface FlutterBinaryCodec : NSObject <FlutterMessageCodec>
	[BaseType (typeof(NSObject))]
	interface FlutterBinaryCodec : FlutterMessageCodec
    {
	}

	// @interface FlutterStringCodec : NSObject <FlutterMessageCodec>
	[BaseType (typeof(NSObject))]
	interface FlutterStringCodec : FlutterMessageCodec
    {
	}

	// @interface FlutterJSONMessageCodec : NSObject <FlutterMessageCodec>
	[BaseType (typeof(NSObject))]
	interface FlutterJSONMessageCodec : FlutterMessageCodec
    {
	}


    // @interface FlutterStandardWriter : NSObject
    [BaseType (typeof(NSObject))]
	interface FlutterStandardWriter
	{
		// -(instancetype _Nonnull)initWithData:(NSMutableData * _Nonnull)data;
		[Export ("initWithData:")]
		IntPtr Constructor (NSMutableData data);

		// -(void)writeByte:(UInt8)value;
		[Export ("writeByte:")]
		void WriteByte (byte value);

		// -(void)writeBytes:(const void * _Nonnull)bytes length:(NSUInteger)length;
		[Export ("writeBytes:length:")]
		unsafe void WriteBytes (IntPtr bytes, nuint length);

		// -(void)writeData:(NSData * _Nonnull)data;
		[Export ("writeData:")]
		void WriteData (NSData data);

		// -(void)writeSize:(UInt32)size;
		[Export ("writeSize:")]
		void WriteSize (uint size);

		// -(void)writeAlignment:(UInt8)alignment;
		[Export ("writeAlignment:")]
		void WriteAlignment (byte alignment);

		// -(void)writeUTF8:(NSString * _Nonnull)value;
		[Export ("writeUTF8:")]
		void WriteUTF8 (string value);

		// -(void)writeValue:(id _Nonnull)value;
		[Export ("writeValue:")]
		void WriteValue (NSObject value);
	}

	// @interface FlutterStandardReader : NSObject
	[BaseType (typeof(NSObject))]
	interface FlutterStandardReader
	{
		// -(instancetype _Nonnull)initWithData:(NSData * _Nonnull)data;
		[Export ("initWithData:")]
		IntPtr Constructor (NSData data);

		// -(BOOL)hasMore;
		[Export ("hasMore")]
		bool HasMore { get; }

		// -(UInt8)readByte;
		[Export("readByte")]
		byte ReadByte();

		// -(void)readBytes:(void * _Nonnull)destination length:(NSUInteger)length;
		[Export ("readBytes:length:")]
		unsafe void ReadBytes (IntPtr destination, nuint length);

		// -(NSData * _Nonnull)readData:(NSUInteger)length;
		[Export ("readData:")]
		NSData ReadData (nuint length);

		// -(UInt32)readSize;
		[Export("readSize")]
		uint ReadSize();

		// -(void)readAlignment:(UInt8)alignment;
		[Export ("readAlignment:")]
		void ReadAlignment (byte alignment);

		// -(NSString * _Nonnull)readUTF8;
		[Export("readUTF8")]
		string ReadUTF8();

		// -(id _Nullable)readValue;
		[NullAllowed, Export("readValue")]
		[return: NullAllowed]
		NSObject ReadValue();

		// -(id _Nullable)readValueOfType:(UInt8)type;
		[Export ("readValueOfType:")]
		[return: NullAllowed]
		NSObject ReadValueOfType (byte type);
	}

	// @interface FlutterStandardReaderWriter : NSObject
	[BaseType (typeof(NSObject))]
	interface FlutterStandardReaderWriter
	{
		// -(FlutterStandardWriter * _Nonnull)writerWithData:(NSMutableData * _Nonnull)data;
		[Export ("writerWithData:")]
		FlutterStandardWriter WriterWithData (NSMutableData data);

		// -(FlutterStandardReader * _Nonnull)readerWithData:(NSData * _Nonnull)data;
		[Export ("readerWithData:")]
		FlutterStandardReader ReaderWithData (NSData data);
	}

	// @interface FlutterStandardMessageCodec : NSObject <FlutterMessageCodec>
	[BaseType (typeof(NSObject))]
	interface FlutterStandardMessageCodec : FlutterMessageCodec
	{
		// +(instancetype _Nonnull)codecWithReaderWriter:(FlutterStandardReaderWriter * _Nonnull)readerWriter;
		[Static]
		[Export ("codecWithReaderWriter:")]
		FlutterStandardMessageCodec CodecWithReaderWriter (FlutterStandardReaderWriter readerWriter);
	}

	// @interface FlutterMethodCall : NSObject
	[BaseType (typeof(NSObject))]
	interface FlutterMethodCall
	{
		// +(instancetype _Nonnull)methodCallWithMethodName:(NSString * _Nonnull)method arguments:(id _Nullable)arguments;
		[Static]
		[Export ("methodCallWithMethodName:arguments:")]
		FlutterMethodCall MethodCallWithMethodName (string method, [NullAllowed] NSObject arguments);

		// @property (readonly, nonatomic) NSString * _Nonnull method;
		[Export ("method")]
		string Method { get; }

		// @property (readonly, nonatomic) id _Nullable arguments;
		[NullAllowed, Export ("arguments")]
		NSObject Arguments { get; }
	}

	// @interface FlutterError : NSObject
	[BaseType (typeof(NSObject))]
	interface FlutterError
	{
		// +(instancetype _Nonnull)errorWithCode:(NSString * _Nonnull)code message:(NSString * _Nullable)message details:(id _Nullable)details;
		[Static]
		[Export ("errorWithCode:message:details:")]
		FlutterError ErrorWithCode (string code, [NullAllowed] string message, [NullAllowed] NSObject details);

		// @property (readonly, nonatomic) NSString * _Nonnull code;
		[Export ("code")]
		string Code { get; }

		// @property (readonly, nonatomic) NSString * _Nullable message;
		[NullAllowed, Export ("message")]
		string Message { get; }

		// @property (readonly, nonatomic) id _Nullable details;
		[NullAllowed, Export ("details")]
		NSObject Details { get; }
	}

	// @interface FlutterStandardTypedData : NSObject
	[BaseType (typeof(NSObject))]
	interface FlutterStandardTypedData
	{
		// +(instancetype _Nonnull)typedDataWithBytes:(NSData * _Nonnull)data;
		[Static]
		[Export ("typedDataWithBytes:")]
		FlutterStandardTypedData TypedDataWithBytes (NSData data);

		// +(instancetype _Nonnull)typedDataWithInt32:(NSData * _Nonnull)data;
		[Static]
		[Export ("typedDataWithInt32:")]
		FlutterStandardTypedData TypedDataWithInt32 (NSData data);

		// +(instancetype _Nonnull)typedDataWithInt64:(NSData * _Nonnull)data;
		[Static]
		[Export ("typedDataWithInt64:")]
		FlutterStandardTypedData TypedDataWithInt64 (NSData data);

		// +(instancetype _Nonnull)typedDataWithFloat32:(NSData * _Nonnull)data;
		[Static]
		[Export ("typedDataWithFloat32:")]
		FlutterStandardTypedData TypedDataWithFloat32 (NSData data);

		// +(instancetype _Nonnull)typedDataWithFloat64:(NSData * _Nonnull)data;
		[Static]
		[Export ("typedDataWithFloat64:")]
		FlutterStandardTypedData TypedDataWithFloat64 (NSData data);

		// @property (readonly, nonatomic) NSData * _Nonnull data;
		[Export ("data")]
		NSData Data { get; }

		// @property (readonly, nonatomic) FlutterStandardDataType type;
		[Export ("type")]
		FlutterStandardDataType Type { get; }

		// @property (readonly, nonatomic) UInt32 elementCount;
		[Export ("elementCount")]
		uint ElementCount { get; }

		// @property (readonly, nonatomic) UInt8 elementSize;
		[Export ("elementSize")]
		byte ElementSize { get; }
	}

    // @protocol FlutterMethodCodec
    /*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/
    [Protocol]
    interface FlutterMethodCodec
    {
        // @required +(instancetype _Nonnull)sharedInstance;
        [Static, Abstract]
        [Export("sharedInstance")]
        IFlutterMethodCodec SharedInstance { get; }

        // @required -(NSData * _Nonnull)encodeMethodCall:(FlutterMethodCall * _Nonnull)methodCall;
        [Abstract]
        [Export("encodeMethodCall:")]
        NSData EncodeMethodCall(FlutterMethodCall methodCall);

        // @required -(FlutterMethodCall * _Nonnull)decodeMethodCall:(NSData * _Nonnull)methodCall;
        [Abstract]
        [Export("decodeMethodCall:")]
        FlutterMethodCall DecodeMethodCall(NSData methodCall);

        // @required -(NSData * _Nonnull)encodeSuccessEnvelope:(id _Nullable)result;
        [Abstract]
        [Export("encodeSuccessEnvelope:")]
        NSData EncodeSuccessEnvelope([NullAllowed] NSObject result);

        // @required -(NSData * _Nonnull)encodeErrorEnvelope:(FlutterError * _Nonnull)error;
        [Abstract]
        [Export("encodeErrorEnvelope:")]
        NSData EncodeErrorEnvelope(FlutterError error);

        // @required -(id _Nullable)decodeEnvelope:(NSData * _Nonnull)envelope;
        [Abstract]
        [Export("decodeEnvelope:")]
        [return: NullAllowed]
        NSObject DecodeEnvelope(NSData envelope);
    }

    // @interface FlutterJSONMethodCodec : NSObject <FlutterMethodCodec>
    [BaseType (typeof(NSObject))]
	interface FlutterJSONMethodCodec : FlutterMethodCodec
	{
	}

	// @interface FlutterStandardMethodCodec : NSObject <FlutterMethodCodec>
	[BaseType (typeof(NSObject))]
	interface FlutterStandardMethodCodec : FlutterMethodCodec
	{
		// +(instancetype _Nonnull)codecWithReaderWriter:(FlutterStandardReaderWriter * _Nonnull)readerWriter;
		[Static]
		[Export ("codecWithReaderWriter:")]
		FlutterStandardMethodCodec CodecWithReaderWriter (FlutterStandardReaderWriter readerWriter);
	}

	// typedef void (^FlutterReply)(id _Nullable);
	delegate void FlutterReply ([NullAllowed] NSObject arg0);

	// typedef void (^FlutterMessageHandler)(id _Nullable, FlutterReply _Nonnull);
	delegate void FlutterMessageHandler ([NullAllowed] NSObject arg0, [CCallback] FlutterReply arg1);

    // @interface FlutterBasicMessageChannel : NSObject
    [BaseType(typeof(NSObject))]
    interface FlutterBasicMessageChannel : FlutterBinaryMessenger
    {
        // +(instancetype _Nonnull)messageChannelWithName:(NSString * _Nonnull)name binaryMessenger:(NSObject<FlutterBinaryMessenger> * _Nonnull)messenger;
        [Static]
        [Export("messageChannelWithName:binaryMessenger:")]
        FlutterBasicMessageChannel MessageChannelWithName(string name, IFlutterBinaryMessenger messenger);

        // +(instancetype _Nonnull)messageChannelWithName:(NSString * _Nonnull)name binaryMessenger:(NSObject<FlutterBinaryMessenger> * _Nonnull)messenger codec:(NSObject<FlutterMessageCodec> * _Nonnull)codec;
        [Static]
        [Export("messageChannelWithName:binaryMessenger:codec:")]
        FlutterBasicMessageChannel MessageChannelWithName(string name, IFlutterBinaryMessenger messenger, IFlutterMessageCodec codec);

        // -(instancetype _Nonnull)initWithName:(NSString * _Nonnull)name binaryMessenger:(NSObject<FlutterBinaryMessenger> * _Nonnull)messenger codec:(NSObject<FlutterMessageCodec> * _Nonnull)codec;
        [Export("initWithName:binaryMessenger:codec:")]
        IntPtr Constructor(string name, IFlutterBinaryMessenger messenger, IFlutterMessageCodec codec);

        // -(instancetype _Nonnull)initWithName:(NSString * _Nonnull)name binaryMessenger:(NSObject<FlutterBinaryMessenger> * _Nonnull)messenger codec:(NSObject<FlutterMessageCodec> * _Nonnull)codec taskQueue:(NSObject<FlutterTaskQueue> * _Nullable)taskQueue;
        [Export("initWithName:binaryMessenger:codec:taskQueue:")]
        IntPtr Constructor(string name, IFlutterBinaryMessenger messenger, IFlutterMessageCodec codec, [NullAllowed] IFlutterTaskQueue taskQueue);

        // -(void)sendMessage:(id _Nullable)message;
        [Export("sendMessage:")]
        void SendMessage([NullAllowed] NSObject message);

        // -(void)sendMessage:(id _Nullable)message reply:(FlutterReply _Nullable)callback;
        [Export("sendMessage:reply:")]
        void SendMessage([NullAllowed] NSObject message, [NullAllowed] FlutterReply callback);

        // -(void)setMessageHandler:(FlutterMessageHandler _Nullable)handler;
        [Export("setMessageHandler:")]
        void SetMessageHandler([NullAllowed] FlutterMessageHandler handler);

        // -(void)resizeChannelBuffer:(NSInteger)newSize;
        [Export("resizeChannelBuffer:")]
        void ResizeChannelBuffer(nint newSize);
    }

    // typedef void (^FlutterResult)(id _Nullable);
    delegate void FlutterResult ([NullAllowed] NSObject arg0);

	// typedef void (^FlutterMethodCallHandler)(FlutterMethodCall * _Nonnull, FlutterResult _Nonnull);
	delegate void FlutterMethodCallHandler (FlutterMethodCall arg0, [CCallback] FlutterResult arg1);


    // @interface FlutterMethodChannel : NSObject
    [BaseType(typeof(NSObject))]
    interface FlutterMethodChannel : FlutterBinaryMessenger
    {
        // +(instancetype _Nonnull)methodChannelWithName:(NSString * _Nonnull)name binaryMessenger:(NSObject<FlutterBinaryMessenger> * _Nonnull)messenger;
        [Static]
        [Export("methodChannelWithName:binaryMessenger:")]
        FlutterMethodChannel Create(string name, IFlutterBinaryMessenger messenger);

        // +(instancetype _Nonnull)methodChannelWithName:(NSString * _Nonnull)name binaryMessenger:(NSObject<FlutterBinaryMessenger> * _Nonnull)messenger codec:(NSObject<FlutterMethodCodec> * _Nonnull)codec;
        [Static]
        [Export("methodChannelWithName:binaryMessenger:codec:")]
        FlutterMethodChannel Create(string name, IFlutterBinaryMessenger messenger, IFlutterMethodCodec codec);

        // -(instancetype _Nonnull)initWithName:(NSString * _Nonnull)name binaryMessenger:(NSObject<FlutterBinaryMessenger> * _Nonnull)messenger codec:(NSObject<FlutterMethodCodec> * _Nonnull)codec;
        [Export("initWithName:binaryMessenger:codec:")]
        IntPtr Constructor(string name, IFlutterBinaryMessenger messenger, IFlutterMethodCodec codec);

        // -(instancetype _Nonnull)initWithName:(NSString * _Nonnull)name binaryMessenger:(NSObject<FlutterBinaryMessenger> * _Nonnull)messenger codec:(NSObject<FlutterMethodCodec> * _Nonnull)codec taskQueue:(NSObject<FlutterTaskQueue> * _Nullable)taskQueue;
        [Export("initWithName:binaryMessenger:codec:taskQueue:")]
        IntPtr Constructor(string name, IFlutterBinaryMessenger messenger, IFlutterMethodCodec codec, [NullAllowed] IFlutterTaskQueue taskQueue);

        // -(void)invokeMethod:(NSString * _Nonnull)method arguments:(id _Nullable)arguments;
        [Export("invokeMethod:arguments:")]
        void InvokeMethod(string method, [NullAllowed] NSObject arguments);

        // -(void)invokeMethod:(NSString * _Nonnull)method arguments:(id _Nullable)arguments result:(FlutterResult _Nullable)callback;
        [Export("invokeMethod:arguments:result:")]
        void InvokeMethod(string method, [NullAllowed] NSObject arguments, [NullAllowed] FlutterResult callback);

        // -(void)setMethodCallHandler:(FlutterMethodCallHandler _Nullable)handler;
        [Export("setMethodCallHandler:")]
        void SetMethodCallHandler([NullAllowed] FlutterMethodCallHandler handler);

        // -(void)resizeChannelBuffer:(NSInteger)newSize;
        [Export("resizeChannelBuffer:")]
        void ResizeChannelBuffer(nint newSize);
    }

    // typedef void (^FlutterEventSink)(id _Nullable);
    delegate void FlutterEventSink ([NullAllowed] NSObject arg0);

	// @protocol FlutterStreamHandler
	/*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/[Protocol]
	interface FlutterStreamHandler
	{
		// @required -(FlutterError * _Nullable)onListenWithArguments:(id _Nullable)arguments eventSink:(FlutterEventSink _Nonnull)events;
		[Abstract]
		[Export ("onListenWithArguments:eventSink:")]
		[return: NullAllowed]
		FlutterError OnListenWithArguments ([NullAllowed] NSObject arguments, FlutterEventSink events);

		// @required -(FlutterError * _Nullable)onCancelWithArguments:(id _Nullable)arguments;
		[Abstract]
		[Export ("onCancelWithArguments:")]
		[return: NullAllowed]
		FlutterError OnCancelWithArguments ([NullAllowed] NSObject arguments);
	}

	

	// @interface FlutterEventChannel : NSObject
	[BaseType (typeof(NSObject))]
	interface FlutterEventChannel
	{
		// +(instancetype _Nonnull)eventChannelWithName:(NSString * _Nonnull)name binaryMessenger:(NSObject<FlutterBinaryMessenger> * _Nonnull)messenger;
		[Static]
		[Export ("eventChannelWithName:binaryMessenger:")]
		FlutterEventChannel EventChannelWithName (string name, IFlutterBinaryMessenger messenger);

		// +(instancetype _Nonnull)eventChannelWithName:(NSString * _Nonnull)name binaryMessenger:(NSObject<FlutterBinaryMessenger> * _Nonnull)messenger codec:(NSObject<FlutterMethodCodec> * _Nonnull)codec;
		[Static]
		[Export ("eventChannelWithName:binaryMessenger:codec:")]
		FlutterEventChannel EventChannelWithName (string name, IFlutterBinaryMessenger messenger, IFlutterMethodCodec codec);

		// -(instancetype _Nonnull)initWithName:(NSString * _Nonnull)name binaryMessenger:(NSObject<FlutterBinaryMessenger> * _Nonnull)messenger codec:(NSObject<FlutterMethodCodec> * _Nonnull)codec;
		[Export ("initWithName:binaryMessenger:codec:")]
		IntPtr Constructor (string name, IFlutterBinaryMessenger messenger, IFlutterMethodCodec codec);

		// -(instancetype _Nonnull)initWithName:(NSString * _Nonnull)name binaryMessenger:(NSObject<FlutterBinaryMessenger> * _Nonnull)messenger codec:(NSObject<FlutterMethodCodec> * _Nonnull)codec taskQueue:(NSObject<FlutterTaskQueue> * _Nullable)taskQueue;
		[Export ("initWithName:binaryMessenger:codec:taskQueue:")]
        IntPtr Constructor (string name, IFlutterBinaryMessenger messenger, IFlutterMethodCodec codec, [NullAllowed] IFlutterTaskQueue taskQueue);

		// -(void)setStreamHandler:(NSObject<FlutterStreamHandler> * _Nullable)handler;
		[Export ("setStreamHandler:")]
		void SetStreamHandler ([NullAllowed] IFlutterStreamHandler handler);
	}

	// @protocol FlutterPlatformView <NSObject>
	/*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/[Protocol]
	interface FlutterPlatformView
	{
		// @required -(UIView * _Nonnull)view;
		[Abstract]
		[Export ("view")]
		UIView View { get; }
	}

	// @protocol FlutterPlatformViewFactory <NSObject>
	/*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/[Protocol]
	interface FlutterPlatformViewFactory
	{
		// @required -(NSObject<FlutterPlatformView> * _Nonnull)createWithFrame:(CGRect)frame viewIdentifier:(int64_t)viewId arguments:(id _Nullable)args;
		[Abstract]
		[Export ("createWithFrame:viewIdentifier:arguments:")]
        IFlutterPlatformView ViewIdentifier (CGRect frame, long viewId, [NullAllowed] NSObject args);

		// @optional -(NSObject<FlutterMessageCodec> * _Nonnull)createArgsCodec;
		[Export ("createArgsCodec")]
		IFlutterMessageCodec CreateArgsCodec { get; }
	}

	
    // @protocol FlutterTexture <NSObject>
    /*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/
  [Protocol]
	interface FlutterTexture
	{
		// @required -(CVPixelBufferRef _Nullable)copyPixelBuffer;
		[Abstract]
		[NullAllowed, Export ("copyPixelBuffer")]
		CVPixelBuffer CopyPixelBuffer { get; }

		// @optional -(void)onTextureUnregistered:(NSObject<FlutterTexture> * _Nonnull)texture;
		[Export ("onTextureUnregistered:")]
		void OnTextureUnregistered (IFlutterTexture texture);
	}

	// @protocol FlutterTextureRegistry <NSObject>
	/*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/[Protocol]
	interface FlutterTextureRegistry
	{
		// @required -(int64_t)registerTexture:(NSObject<FlutterTexture> * _Nonnull)texture;
		[Abstract]
		[Export ("registerTexture:")]
		long RegisterTexture (IFlutterTexture texture);

		// @required -(void)textureFrameAvailable:(int64_t)textureId;
		[Abstract]
		[Export ("textureFrameAvailable:")]
		void TextureFrameAvailable (long textureId);

		// @required -(void)unregisterTexture:(int64_t)textureId;
		[Abstract]
		[Export ("unregisterTexture:")]
		void UnregisterTexture (long textureId);
	}

	// @protocol FlutterApplicationLifeCycleDelegate <UNUserNotificationCenterDelegate>
	[Protocol]
	interface FlutterApplicationLifeCycleDelegate : IUNUserNotificationCenterDelegate
	{
		// @optional -(BOOL)application:(UIApplication * _Nonnull)application didFinishLaunchingWithOptions:(NSDictionary * _Nonnull)launchOptions;
		[Export ("application:didFinishLaunchingWithOptions:")]
		bool ApplicationFinishedLaunching(UIApplication application, NSDictionary launchOptions);

		// @optional -(BOOL)application:(UIApplication * _Nonnull)application willFinishLaunchingWithOptions:(NSDictionary * _Nonnull)launchOptions;
		[Export ("application:willFinishLaunchingWithOptions:")]
		bool ApplicationWillFinishLaunching(UIApplication application, NSDictionary launchOptions);

		// @optional -(void)applicationDidBecomeActive:(UIApplication * _Nonnull)application;
		[Export ("applicationDidBecomeActive:")]
		void ApplicationDidBecomeActive (UIApplication application);

		// @optional -(void)applicationWillResignActive:(UIApplication * _Nonnull)application;
		[Export ("applicationWillResignActive:")]
		void ApplicationWillResignActive (UIApplication application);

		// @optional -(void)applicationDidEnterBackground:(UIApplication * _Nonnull)application;
		[Export ("applicationDidEnterBackground:")]
		void ApplicationDidEnterBackground (UIApplication application);

		// @optional -(void)applicationWillEnterForeground:(UIApplication * _Nonnull)application;
		[Export ("applicationWillEnterForeground:")]
		void ApplicationWillEnterForeground (UIApplication application);

		// @optional -(void)applicationWillTerminate:(UIApplication * _Nonnull)application;
		[Export ("applicationWillTerminate:")]
		void ApplicationWillTerminate (UIApplication application);

		// @optional -(void)application:(UIApplication * _Nonnull)application didRegisterUserNotificationSettings:(UIUserNotificationSettings * _Nonnull)notificationSettings __attribute__((availability(ios, introduced=8.0, deprecated=10.0)));
		[Introduced (PlatformName.iOS, 8, 0, message: "See -[UIApplicationDelegate application:didRegisterUserNotificationSettings:] deprecation")]
		[Deprecated (PlatformName.iOS, 10, 0, message: "See -[UIApplicationDelegate application:didRegisterUserNotificationSettings:] deprecation")]
		[Export ("application:didRegisterUserNotificationSettings:")]
		void Application (UIApplication application, UIUserNotificationSettings notificationSettings);

		// @optional -(void)application:(UIApplication * _Nonnull)application didRegisterForRemoteNotificationsWithDeviceToken:(NSData * _Nonnull)deviceToken;
		[Export ("application:didRegisterForRemoteNotificationsWithDeviceToken:")]
		void Application (UIApplication application, NSData deviceToken);

		// @optional -(void)application:(UIApplication * _Nonnull)application didFailToRegisterForRemoteNotificationsWithError:(NSError * _Nonnull)error;
		[Export ("application:didFailToRegisterForRemoteNotificationsWithError:")]
		void Application (UIApplication application, NSError error);

		// @optional -(BOOL)application:(UIApplication * _Nonnull)application didReceiveRemoteNotification:(NSDictionary * _Nonnull)userInfo fetchCompletionHandler:(void (^ _Nonnull)(UIBackgroundFetchResult))completionHandler;
		[Export ("application:didReceiveRemoteNotification:fetchCompletionHandler:")]
		bool Application (UIApplication application, NSDictionary userInfo, Action<UIBackgroundFetchResult> completionHandler);

		// @optional -(void)application:(UIApplication * _Nonnull)application didReceiveLocalNotification:(UILocalNotification * _Nonnull)notification __attribute__((availability(ios, introduced=4.0, deprecated=10.0)));
		[Introduced (PlatformName.iOS, 4, 0, message: "See -[UIApplicationDelegate application:didReceiveLocalNotification:] deprecation")]
		[Deprecated (PlatformName.iOS, 10, 0, message: "See -[UIApplicationDelegate application:didReceiveLocalNotification:] deprecation")]
		[Export ("application:didReceiveLocalNotification:")]
		void Application (UIApplication application, UILocalNotification notification);

		// @optional -(BOOL)application:(UIApplication * _Nonnull)application openURL:(NSURL * _Nonnull)url options:(NSDictionary<UIApplicationOpenURLOptionsKey,id> * _Nonnull)options;
		[Export ("application:openURL:options:")]
		bool Application (UIApplication application, NSUrl url, NSDictionary<NSString, NSObject> options);

		// @optional -(BOOL)application:(UIApplication * _Nonnull)application handleOpenURL:(NSURL * _Nonnull)url;
		[Export ("application:handleOpenURL:")]
		bool Application (UIApplication application, NSUrl url);

		// @optional -(BOOL)application:(UIApplication * _Nonnull)application openURL:(NSURL * _Nonnull)url sourceApplication:(NSString * _Nonnull)sourceApplication annotation:(id _Nonnull)annotation;
		[Export ("application:openURL:sourceApplication:annotation:")]
		bool Application (UIApplication application, NSUrl url, string sourceApplication, NSObject annotation);

		// @optional -(BOOL)application:(UIApplication * _Nonnull)application performActionForShortcutItem:(UIApplicationShortcutItem * _Nonnull)shortcutItem completionHandler:(void (^ _Nonnull)(BOOL))completionHandler __attribute__((availability(ios, introduced=9.0)));
		[iOS (9,0)]
		[Export ("application:performActionForShortcutItem:completionHandler:")]
		bool Application (UIApplication application, UIApplicationShortcutItem shortcutItem, Action<bool> completionHandler);

		// @optional -(BOOL)application:(UIApplication * _Nonnull)application handleEventsForBackgroundURLSession:(NSString * _Nonnull)identifier completionHandler:(void (^ _Nonnull)(void))completionHandler;
		[Export ("application:handleEventsForBackgroundURLSession:completionHandler:")]
		bool Application (UIApplication application, string identifier, Action completionHandler);

		// @optional -(BOOL)application:(UIApplication * _Nonnull)application performFetchWithCompletionHandler:(void (^ _Nonnull)(UIBackgroundFetchResult))completionHandler;
		[Export ("application:performFetchWithCompletionHandler:")]
		bool Application (UIApplication application, Action<UIBackgroundFetchResult> completionHandler);

		// @optional -(BOOL)application:(UIApplication * _Nonnull)application continueUserActivity:(NSUserActivity * _Nonnull)userActivity restorationHandler:(void (^ _Nonnull)(NSArray * _Nonnull))restorationHandler;
		[Export ("application:continueUserActivity:restorationHandler:")]
		bool Application (UIApplication application, NSUserActivity userActivity, Action<NSArray> restorationHandler);
	}

  

    /// <summary>
    /// NOTE: This delegate can be safely excluded from binding as it's only needed by native iOS plugins.
    /// </summary>
    // typedef void (*FlutterPluginRegistrantCallback)(NSObject<FlutterPluginRegistry>* registry);
    delegate void FlutterPluginRegistrantCallback(IFlutterPluginRegistry registry);

    // @protocol FlutterPlugin <NSObject, FlutterApplicationLifeCycleDelegate>
    /*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/
    [Protocol]
	interface FlutterPlugin : FlutterApplicationLifeCycleDelegate
    {
		// @required +(void)registerWithRegistrar:(NSObject<FlutterPluginRegistrar> * _Nonnull)registrar;
		[Static, Abstract]
		[Export ("registerWithRegistrar:")]
		void RegisterWithRegistrar (IFlutterPluginRegistrar registrar);

		// @optional +(void)setPluginRegistrantCallback:(FlutterPluginRegistrantCallback _Nonnull)callback;
		[Static]
		[Export ("setPluginRegistrantCallback:")]
		unsafe void SetPluginRegistrantCallback (FlutterPluginRegistrantCallback callback);

		// @optional -(void)handleMethodCall:(FlutterMethodCall * _Nonnull)call result:(FlutterResult _Nonnull)result;
		[Export ("handleMethodCall:result:")]
		void HandleMethodCall (FlutterMethodCall call, FlutterResult result);

		// @optional -(void)detachFromEngineForRegistrar:(NSObject<FlutterPluginRegistrar> * _Nonnull)registrar;
		[Export ("detachFromEngineForRegistrar:")]
		void DetachFromEngineForRegistrar (IFlutterPluginRegistrar registrar);
	}



	// @protocol FlutterPluginRegistrar <NSObject>
	/*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/[Protocol]
	interface FlutterPluginRegistrar
	{
		// @required -(NSObject<FlutterBinaryMessenger> * _Nonnull)messenger;
		[Abstract]
		[Export ("messenger")]
		IFlutterBinaryMessenger Messenger { get; }

		// @required -(NSObject<FlutterTextureRegistry> * _Nonnull)textures;
		[Abstract]
		[Export ("textures")]
        IFlutterTextureRegistry Textures { get; }

		// @required -(void)registerViewFactory:(NSObject<FlutterPlatformViewFactory> * _Nonnull)factory withId:(NSString * _Nonnull)factoryId;
		[Abstract]
		[Export ("registerViewFactory:withId:")]
		void RegisterViewFactory (IFlutterPlatformViewFactory factory, string factoryId);

		// @required -(void)registerViewFactory:(NSObject<FlutterPlatformViewFactory> * _Nonnull)factory withId:(NSString * _Nonnull)factoryId gestureRecognizersBlockingPolicy:(FlutterPlatformViewGestureRecognizersBlockingPolicy)gestureRecognizersBlockingPolicy;
		[Abstract]
		[Export ("registerViewFactory:withId:gestureRecognizersBlockingPolicy:")]
		void RegisterViewFactory (IFlutterPlatformViewFactory factory, string factoryId, FlutterPlatformViewGestureRecognizersBlockingPolicy gestureRecognizersBlockingPolicy);

		// @required -(void)publish:(NSObject * _Nonnull)value;
		[Abstract]
		[Export ("publish:")]
		void Publish (NSObject value);

		// @required -(void)addMethodCallDelegate:(NSObject<FlutterPlugin> * _Nonnull)delegate channel:(FlutterMethodChannel * _Nonnull)channel;
		[Abstract]
		[Export ("addMethodCallDelegate:channel:")]
		void AddMethodCallDelegate (IFlutterPlugin @delegate, FlutterMethodChannel channel);

		// @required -(void)addApplicationDelegate:(NSObject<FlutterPlugin> * _Nonnull)delegate;
		[Abstract]
		[Export ("addApplicationDelegate:")]
		void AddApplicationDelegate (IFlutterPlugin @delegate);

		// @required -(NSString * _Nonnull)lookupKeyForAsset:(NSString * _Nonnull)asset;
		[Abstract]
		[Export ("lookupKeyForAsset:")]
		string LookupKeyForAsset (string asset);

		// @required -(NSString * _Nonnull)lookupKeyForAsset:(NSString * _Nonnull)asset fromPackage:(NSString * _Nonnull)package;
		[Abstract]
		[Export ("lookupKeyForAsset:fromPackage:")]
		string LookupKeyForAsset (string asset, string package);
	}

    
    // @protocol FlutterPluginRegistry <NSObject>
    /*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/
    [Protocol]
	interface FlutterPluginRegistry
	{
		// @required -(NSObject<FlutterPluginRegistrar> * _Nullable)registrarForPlugin:(NSString * _Nonnull)pluginKey;
		[Abstract]
		[Export ("registrarForPlugin:")]
		[return: NullAllowed]
        IFlutterPluginRegistrar RegistrarForPlugin (string pluginKey);

		// @required -(BOOL)hasPlugin:(NSString * _Nonnull)pluginKey;
		[Abstract]
		[Export ("hasPlugin:")]
		bool HasPlugin (string pluginKey);

		// @required -(NSObject * _Nullable)valuePublishedByPlugin:(NSString * _Nonnull)pluginKey;
		[Abstract]
		[Export ("valuePublishedByPlugin:")]
		[return: NullAllowed]
		NSObject ValuePublishedByPlugin (string pluginKey);
	}

	// @protocol FlutterAppLifeCycleProvider <UNUserNotificationCenterDelegate>
	/*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/[Protocol]
	interface FlutterAppLifeCycleProvider : IUNUserNotificationCenterDelegate
	{
		// @required -(void)addApplicationLifeCycleDelegate:(NSObject<FlutterApplicationLifeCycleDelegate> * _Nonnull)delegate;
		[Abstract]
		[Export ("addApplicationLifeCycleDelegate:")]
		void AddApplicationLifeCycleDelegate (IFlutterApplicationLifeCycleDelegate @delegate);
    }

	

    // @interface FlutterAppDelegate : UIResponder <UIApplicationDelegate, FlutterPluginRegistry, FlutterAppLifeCycleProvider>
    [BaseType (typeof(UIResponder))]
	interface FlutterAppDelegate : IUIApplicationDelegate, FlutterPluginRegistry, FlutterAppLifeCycleProvider
	{
		// @property (nonatomic, strong) UIWindow * window;
		[Export ("window", ArgumentSemantic.Strong)]
		UIWindow Window { get; set; }

        /// <summary>
        /// NOTE: DO NOT REMOVE this method! It's required as we're (re)defining a base <see href="https://docs.microsoft.com/en-us/dotnet/api/uikit.uiapplicationdelegate?view=xamarin-ios-sdk-12">UIApplicationDelegate</see>.
        /// </summary>
        // @optional -(BOOL)application:(UIApplication * _Nonnull)application didFinishLaunchingWithOptions:(NSDictionary * _Nonnull)launchOptions;
        [Export("application:didFinishLaunchingWithOptions:")]
        bool FinishedLaunching(UIApplication application, [NullAllowed] NSDictionary launchOptions);
    }

	// @interface FlutterCallbackInformation : NSObject
	[BaseType (typeof(NSObject))]
	interface FlutterCallbackInformation
	{
		// @property (copy) NSString * callbackName;
		[Export ("callbackName")]
		string CallbackName { get; set; }

		// @property (copy) NSString * callbackClassName;
		[Export ("callbackClassName")]
		string CallbackClassName { get; set; }

		// @property (copy) NSString * callbackLibraryPath;
		[Export ("callbackLibraryPath")]
		string CallbackLibraryPath { get; set; }
	}

	// @interface FlutterCallbackCache : NSObject
	[BaseType (typeof(NSObject))]
	interface FlutterCallbackCache
	{
		// +(FlutterCallbackInformation *)lookupCallbackInformation:(int64_t)handle;
		[Static]
		[Export ("lookupCallbackInformation:")]
		FlutterCallbackInformation LookupCallbackInformation (long handle);
	}

	// @interface FlutterDartProject : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface FlutterDartProject
	{
		// -(instancetype _Nonnull)initWithPrecompiledDartBundle:(NSBundle * _Nullable)bundle __attribute__((objc_designated_initializer));
		[Export ("initWithPrecompiledDartBundle:")]
		[DesignatedInitializer]
		IntPtr Constructor ([NullAllowed] NSBundle bundle);

		// +(NSString * _Nonnull)lookupKeyForAsset:(NSString * _Nonnull)asset;
		[Static]
		[Export ("lookupKeyForAsset:")]
		string LookupKeyForAsset (string asset);

		// +(NSString * _Nonnull)lookupKeyForAsset:(NSString * _Nonnull)asset fromBundle:(NSBundle * _Nullable)bundle;
		[Static]
		[Export ("lookupKeyForAsset:fromBundle:")]
		string LookupKeyForAsset (string asset, [NullAllowed] NSBundle bundle);

		// +(NSString * _Nonnull)lookupKeyForAsset:(NSString * _Nonnull)asset fromPackage:(NSString * _Nonnull)package;
		[Static]
		[Export ("lookupKeyForAsset:fromPackage:")]
		string LookupKeyForAsset (string asset, string package);

		// +(NSString * _Nonnull)lookupKeyForAsset:(NSString * _Nonnull)asset fromPackage:(NSString * _Nonnull)package fromBundle:(NSBundle * _Nullable)bundle;
		[Static]
		[Export ("lookupKeyForAsset:fromPackage:fromBundle:")]
		string LookupKeyForAsset (string asset, string package, [NullAllowed] NSBundle bundle);

		// +(NSString * _Nonnull)defaultBundleIdentifier;
		[Static]
		[Export ("defaultBundleIdentifier")]
		string DefaultBundleIdentifier { get; }
	}

    

    // @interface FlutterEngine : NSObject <FlutterTextureRegistry, FlutterPluginRegistry>
    [BaseType (typeof(NSObject))]
	interface FlutterEngine : FlutterTextureRegistry, FlutterPluginRegistry
	{
		// -(instancetype _Nonnull)initWithName:(NSString * _Nonnull)labelPrefix;
		[Export ("initWithName:")]
		IntPtr Constructor (string labelPrefix);

		// -(instancetype _Nonnull)initWithName:(NSString * _Nonnull)labelPrefix project:(FlutterDartProject * _Nullable)project;
		[Export ("initWithName:project:")]
        IntPtr Constructor (string labelPrefix, [NullAllowed] FlutterDartProject project);

		// -(instancetype _Nonnull)initWithName:(NSString * _Nonnull)labelPrefix project:(FlutterDartProject * _Nullable)project allowHeadlessExecution:(BOOL)allowHeadlessExecution;
		[Export ("initWithName:project:allowHeadlessExecution:")]
        IntPtr Constructor (string labelPrefix, [NullAllowed] FlutterDartProject project, bool allowHeadlessExecution);

		// -(instancetype _Nonnull)initWithName:(NSString * _Nonnull)labelPrefix project:(FlutterDartProject * _Nullable)project allowHeadlessExecution:(BOOL)allowHeadlessExecution restorationEnabled:(BOOL)restorationEnabled __attribute__((objc_designated_initializer));
		[Export ("initWithName:project:allowHeadlessExecution:restorationEnabled:")]
		[DesignatedInitializer]
        IntPtr Constructor (string labelPrefix, [NullAllowed] FlutterDartProject project, bool allowHeadlessExecution, bool restorationEnabled);

		// -(BOOL)run;
		[Export("run")]
		bool Run();

		// -(BOOL)runWithEntrypoint:(NSString * _Nullable)entrypoint;
		[Export ("runWithEntrypoint:")]
		bool RunWithEntrypoint ([NullAllowed] string entrypoint);

		// -(BOOL)runWithEntrypoint:(NSString * _Nullable)entrypoint initialRoute:(NSString * _Nullable)initialRoute;
		[Export ("runWithEntrypoint:initialRoute:")]
		bool RunWithEntrypoint ([NullAllowed] string entrypoint, [NullAllowed] string initialRoute);

		// -(BOOL)runWithEntrypoint:(NSString * _Nullable)entrypoint libraryURI:(NSString * _Nullable)uri;
		[Export ("runWithEntrypoint:libraryURI:")]
		bool RunWithUri([NullAllowed] string entrypoint, [NullAllowed] string uri);

		// -(BOOL)runWithEntrypoint:(NSString * _Nullable)entrypoint libraryURI:(NSString * _Nullable)libraryURI initialRoute:(NSString * _Nullable)initialRoute;
		[Export ("runWithEntrypoint:libraryURI:initialRoute:")]
		bool RunWithEntrypoint ([NullAllowed] string entrypoint, [NullAllowed] string libraryURI, [NullAllowed] string initialRoute);

		// -(BOOL)runWithEntrypoint:(NSString * _Nullable)entrypoint libraryURI:(NSString * _Nullable)libraryURI initialRoute:(NSString * _Nullable)initialRoute entrypointArgs:(NSArray<NSString *> * _Nullable)entrypointArgs;
		[Export ("runWithEntrypoint:libraryURI:initialRoute:entrypointArgs:")]
		bool RunWithEntrypoint ([NullAllowed] string entrypoint, [NullAllowed] string libraryURI, [NullAllowed] string initialRoute, [NullAllowed] string[] entrypointArgs);

		// -(void)destroyContext;
		[Export ("destroyContext")]
		void DestroyContext ();

		// -(void)ensureSemanticsEnabled;
		[Export ("ensureSemanticsEnabled")]
		void EnsureSemanticsEnabled ();

		// @property (nonatomic, weak) FlutterViewController * _Nullable viewController;
		[NullAllowed, Export ("viewController", ArgumentSemantic.Weak)]
		FlutterViewController ViewController { get; set; }

		// @property (readonly, nonatomic) FlutterMethodChannel * _Nullable localizationChannel;
		[NullAllowed, Export ("localizationChannel")]
		FlutterMethodChannel LocalizationChannel { get; }

		// @property (readonly, nonatomic) FlutterMethodChannel * _Nonnull navigationChannel;
		[Export ("navigationChannel")]
		FlutterMethodChannel NavigationChannel { get; }

		// @property (readonly, nonatomic) FlutterMethodChannel * _Nonnull restorationChannel;
		[Export ("restorationChannel")]
		FlutterMethodChannel RestorationChannel { get; }

		// @property (readonly, nonatomic) FlutterMethodChannel * _Nonnull platformChannel;
		[Export ("platformChannel")]
		FlutterMethodChannel PlatformChannel { get; }

		// @property (readonly, nonatomic) FlutterMethodChannel * _Nonnull textInputChannel;
		[Export ("textInputChannel")]
		FlutterMethodChannel TextInputChannel { get; }

		// @property (readonly, nonatomic) FlutterBasicMessageChannel * _Nonnull lifecycleChannel;
		[Export ("lifecycleChannel")]
		FlutterBasicMessageChannel LifecycleChannel { get; }

		// @property (readonly, nonatomic) FlutterBasicMessageChannel * _Nonnull systemChannel;
		[Export ("systemChannel")]
		FlutterBasicMessageChannel SystemChannel { get; }

		// @property (readonly, nonatomic) FlutterBasicMessageChannel * _Nonnull settingsChannel;
		[Export ("settingsChannel")]
		FlutterBasicMessageChannel SettingsChannel { get; }

		// @property (readonly, nonatomic) FlutterBasicMessageChannel * _Nonnull keyEventChannel;
		[Export ("keyEventChannel")]
		FlutterBasicMessageChannel KeyEventChannel { get; }

		// @property (readonly, nonatomic) NSURL * _Nullable observatoryUrl;
		[NullAllowed, Export ("observatoryUrl")]
		NSUrl ObservatoryUrl { get; }

		// @property (readonly, nonatomic) NSObject<FlutterBinaryMessenger> * _Nonnull binaryMessenger;
		[Export ("binaryMessenger")]
		IFlutterBinaryMessenger BinaryMessenger { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable isolateId;
		[NullAllowed, Export ("isolateId")]
		string IsolateId { get; }

		// @property (assign, nonatomic) BOOL isGpuDisabled;
		[Export ("isGpuDisabled")]
		bool IsGpuDisabled { get; set; }
	}

	// @interface FlutterEngineGroupOptions : NSObject
	[BaseType (typeof(NSObject))]
	interface FlutterEngineGroupOptions
	{
		// @property (copy, nonatomic) NSString * _Nullable entrypoint;
		[NullAllowed, Export ("entrypoint")]
		string Entrypoint { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable libraryURI;
		[NullAllowed, Export ("libraryURI")]
		string LibraryURI { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable initialRoute;
		[NullAllowed, Export ("initialRoute")]
		string InitialRoute { get; set; }

		// @property (retain, nonatomic) NSArray<NSString *> * _Nullable entrypointArgs;
		[NullAllowed, Export ("entrypointArgs", ArgumentSemantic.Retain)]
		string[] EntrypointArgs { get; set; }
	}

	// @interface FlutterEngineGroup : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface FlutterEngineGroup
	{
		// -(instancetype _Nonnull)initWithName:(NSString * _Nonnull)name project:(FlutterDartProject * _Nullable)project __attribute__((objc_designated_initializer));
		[Export ("initWithName:project:")]
		[DesignatedInitializer]
		IntPtr Constructor (string name, [NullAllowed] FlutterDartProject project);

		// -(FlutterEngine * _Nonnull)makeEngineWithEntrypoint:(NSString * _Nullable)entrypoint libraryURI:(NSString * _Nullable)libraryURI;
		[Export ("makeEngineWithEntrypoint:libraryURI:")]
		FlutterEngine MakeEngineWithEntrypoint ([NullAllowed] string entrypoint, [NullAllowed] string libraryURI);

		// -(FlutterEngine * _Nonnull)makeEngineWithEntrypoint:(NSString * _Nullable)entrypoint libraryURI:(NSString * _Nullable)libraryURI initialRoute:(NSString * _Nullable)initialRoute;
		[Export ("makeEngineWithEntrypoint:libraryURI:initialRoute:")]
		FlutterEngine MakeEngineWithEntrypoint ([NullAllowed] string entrypoint, [NullAllowed] string libraryURI, [NullAllowed] string initialRoute);

		// -(FlutterEngine * _Nonnull)makeEngineWithOptions:(FlutterEngineGroupOptions * _Nullable)options;
		[Export ("makeEngineWithOptions:")]
		FlutterEngine MakeEngineWithOptions ([NullAllowed] FlutterEngineGroupOptions options);
	}

	// typedef void (^FlutterHeadlessDartRunnerCallback)(BOOL);
	delegate void FlutterHeadlessDartRunnerCallback (bool arg0);

	// @interface FlutterHeadlessDartRunner : FlutterEngine
	[BaseType (typeof(FlutterEngine))]
	interface FlutterHeadlessDartRunner
	{
		// -(instancetype)initWithName:(NSString *)labelPrefix project:(FlutterDartProject *)projectOrNil;
		[Export ("initWithName:project:")]
        IntPtr Constructor (string labelPrefix, FlutterDartProject projectOrNil);

		// -(instancetype)initWithName:(NSString *)labelPrefix project:(FlutterDartProject *)projectOrNil allowHeadlessExecution:(BOOL)allowHeadlessExecution;
		[Export ("initWithName:project:allowHeadlessExecution:")]
        IntPtr Constructor (string labelPrefix, FlutterDartProject projectOrNil, bool allowHeadlessExecution);

		// -(instancetype)initWithName:(NSString *)labelPrefix project:(FlutterDartProject *)projectOrNil allowHeadlessExecution:(BOOL)allowHeadlessExecution restorationEnabled:(BOOL)restorationEnabled __attribute__((objc_designated_initializer));
		[Export ("initWithName:project:allowHeadlessExecution:restorationEnabled:")]
		[DesignatedInitializer]
        IntPtr Constructor (string labelPrefix, FlutterDartProject projectOrNil, bool allowHeadlessExecution, bool restorationEnabled);
	}

	// @interface FlutterPluginAppLifeCycleDelegate : NSObject <UNUserNotificationCenterDelegate>
	[BaseType (typeof(NSObject))]
	interface FlutterPluginAppLifeCycleDelegate : IUNUserNotificationCenterDelegate
	{
		// -(void)addDelegate:(NSObject<FlutterApplicationLifeCycleDelegate> * _Nonnull)delegate;
		[Export ("addDelegate:")]
		void AddDelegate (IFlutterApplicationLifeCycleDelegate @delegate);

		// -(BOOL)application:(UIApplication * _Nonnull)application didFinishLaunchingWithOptions:(NSDictionary * _Nonnull)launchOptions;
		[Export ("application:didFinishLaunchingWithOptions:")]
		bool ApplicationFinishedLaunching(UIApplication application, NSDictionary launchOptions);

		// -(BOOL)application:(UIApplication * _Nonnull)application willFinishLaunchingWithOptions:(NSDictionary * _Nonnull)launchOptions;
		[Export ("application:willFinishLaunchingWithOptions:")]
		bool ApplicationWillFinishLaunching(UIApplication application, NSDictionary launchOptions);

		// -(void)application:(UIApplication * _Nonnull)application didRegisterUserNotificationSettings:(UIUserNotificationSettings * _Nonnull)notificationSettings __attribute__((availability(ios, introduced=8.0, deprecated=10.0)));
		[Introduced (PlatformName.iOS, 8, 0, message: "See -[UIApplicationDelegate application:didRegisterUserNotificationSettings:] deprecation")]
		[Deprecated (PlatformName.iOS, 10, 0, message: "See -[UIApplicationDelegate application:didRegisterUserNotificationSettings:] deprecation")]
		[Export ("application:didRegisterUserNotificationSettings:")]
		void Application (UIApplication application, UIUserNotificationSettings notificationSettings);

		// -(void)application:(UIApplication * _Nonnull)application didRegisterForRemoteNotificationsWithDeviceToken:(NSData * _Nonnull)deviceToken;
		[Export ("application:didRegisterForRemoteNotificationsWithDeviceToken:")]
		void Application (UIApplication application, NSData deviceToken);

		// -(void)application:(UIApplication * _Nonnull)application didFailToRegisterForRemoteNotificationsWithError:(NSError * _Nonnull)error;
		[Export ("application:didFailToRegisterForRemoteNotificationsWithError:")]
		void Application (UIApplication application, NSError error);

		// -(void)application:(UIApplication * _Nonnull)application didReceiveRemoteNotification:(NSDictionary * _Nonnull)userInfo fetchCompletionHandler:(void (^ _Nonnull)(UIBackgroundFetchResult))completionHandler;
		[Export ("application:didReceiveRemoteNotification:fetchCompletionHandler:")]
		void Application (UIApplication application, NSDictionary userInfo, Action<UIBackgroundFetchResult> completionHandler);

		// -(void)application:(UIApplication * _Nonnull)application didReceiveLocalNotification:(UILocalNotification * _Nonnull)notification __attribute__((availability(ios, introduced=4.0, deprecated=10.0)));
		[Introduced (PlatformName.iOS, 4, 0, message: "See -[UIApplicationDelegate application:didReceiveLocalNotification:] deprecation")]
		[Deprecated (PlatformName.iOS, 10, 0, message: "See -[UIApplicationDelegate application:didReceiveLocalNotification:] deprecation")]
		[Export ("application:didReceiveLocalNotification:")]
		void Application (UIApplication application, UILocalNotification notification);

		// -(BOOL)application:(UIApplication * _Nonnull)application openURL:(NSURL * _Nonnull)url options:(NSDictionary<UIApplicationOpenURLOptionsKey,id> * _Nonnull)options;
		[Export ("application:openURL:options:")]
		bool Application (UIApplication application, NSUrl url, NSDictionary<NSString, NSObject> options);

		// -(BOOL)application:(UIApplication * _Nonnull)application handleOpenURL:(NSURL * _Nonnull)url;
		[Export ("application:handleOpenURL:")]
		bool Application (UIApplication application, NSUrl url);

		// -(BOOL)application:(UIApplication * _Nonnull)application openURL:(NSURL * _Nonnull)url sourceApplication:(NSString * _Nonnull)sourceApplication annotation:(id _Nonnull)annotation;
		[Export ("application:openURL:sourceApplication:annotation:")]
		bool Application (UIApplication application, NSUrl url, string sourceApplication, NSObject annotation);

		// -(void)application:(UIApplication * _Nonnull)application performActionForShortcutItem:(UIApplicationShortcutItem * _Nonnull)shortcutItem completionHandler:(void (^ _Nonnull)(BOOL))completionHandler __attribute__((availability(ios, introduced=9.0)));
		[iOS (9,0)]
		[Export ("application:performActionForShortcutItem:completionHandler:")]
		void Application (UIApplication application, UIApplicationShortcutItem shortcutItem, Action<bool> completionHandler);

		// -(BOOL)application:(UIApplication * _Nonnull)application handleEventsForBackgroundURLSession:(NSString * _Nonnull)identifier completionHandler:(void (^ _Nonnull)(void))completionHandler;
		[Export ("application:handleEventsForBackgroundURLSession:completionHandler:")]
		bool Application (UIApplication application, string identifier, Action completionHandler);

		// -(BOOL)application:(UIApplication * _Nonnull)application performFetchWithCompletionHandler:(void (^ _Nonnull)(UIBackgroundFetchResult))completionHandler;
		[Export ("application:performFetchWithCompletionHandler:")]
		bool Application (UIApplication application, Action<UIBackgroundFetchResult> completionHandler);

		// -(BOOL)application:(UIApplication * _Nonnull)application continueUserActivity:(NSUserActivity * _Nonnull)userActivity restorationHandler:(void (^ _Nonnull)(NSArray * _Nonnull))restorationHandler;
		[Export ("application:continueUserActivity:restorationHandler:")]
		bool Application (UIApplication application, NSUserActivity userActivity, Action<NSArray> restorationHandler);
	}

	

	// @interface FlutterViewController : UIViewController <FlutterTextureRegistry, FlutterPluginRegistry, UIGestureRecognizerDelegate>
	[BaseType (typeof(UIViewController))]
	interface FlutterViewController : FlutterTextureRegistry, FlutterPluginRegistry, IUIGestureRecognizerDelegate
	{
		// -(instancetype _Nonnull)initWithEngine:(FlutterEngine * _Nonnull)engine nibName:(NSString * _Nullable)nibName bundle:(NSBundle * _Nullable)nibBundle __attribute__((objc_designated_initializer));
		[Export ("initWithEngine:nibName:bundle:")]
		[DesignatedInitializer]
		IntPtr Constructor (FlutterEngine engine, [NullAllowed] string nibName, [NullAllowed] NSBundle nibBundle);

		// -(instancetype _Nonnull)initWithProject:(FlutterDartProject * _Nullable)project nibName:(NSString * _Nullable)nibName bundle:(NSBundle * _Nullable)nibBundle __attribute__((objc_designated_initializer));
		[Export ("initWithProject:nibName:bundle:")]
		[DesignatedInitializer]
        IntPtr Constructor ([NullAllowed] FlutterDartProject project, [NullAllowed] string nibName, [NullAllowed] NSBundle nibBundle);

		// -(instancetype _Nonnull)initWithProject:(FlutterDartProject * _Nullable)project initialRoute:(NSString * _Nullable)initialRoute nibName:(NSString * _Nullable)nibName bundle:(NSBundle * _Nullable)nibBundle __attribute__((objc_designated_initializer));
		[Export ("initWithProject:initialRoute:nibName:bundle:")]
		[DesignatedInitializer]
        IntPtr Constructor ([NullAllowed] FlutterDartProject project, [NullAllowed] string initialRoute, [NullAllowed] string nibName, [NullAllowed] NSBundle nibBundle);

		//// -(instancetype _Nonnull)initWithCoder:(NSCoder * _Nonnull)aDecoder __attribute__((objc_designated_initializer));
		//[Export ("initWithCoder:")]
		//[DesignatedInitializer]
  //      IntPtr Constructor (NSCoder aDecoder);

		// -(void)setFlutterViewDidRenderCallback:(void (^ _Nonnull)(void))callback;
		[Export ("setFlutterViewDidRenderCallback:")]
		void SetFlutterViewDidRenderCallback (Action callback);

		// -(NSString * _Nonnull)lookupKeyForAsset:(NSString * _Nonnull)asset;
		[Export ("lookupKeyForAsset:")]
		string LookupKeyForAsset (string asset);

		// -(NSString * _Nonnull)lookupKeyForAsset:(NSString * _Nonnull)asset fromPackage:(NSString * _Nonnull)package;
		[Export ("lookupKeyForAsset:fromPackage:")]
		string LookupKeyForAsset (string asset, string package);

		// -(void)setInitialRoute:(NSString * _Nonnull)route __attribute__((deprecated("Use FlutterViewController initializer to specify initial route")));
		[Export ("setInitialRoute:")]
		void SetInitialRoute (string route);

		// -(void)popRoute;
		[Export ("popRoute")]
		void PopRoute ();

		// -(void)pushRoute:(NSString * _Nonnull)route;
		[Export ("pushRoute:")]
		void PushRoute (string route);

		// -(id<FlutterPluginRegistry> _Nonnull)pluginRegistry;
		[Export ("pluginRegistry")]
		IFlutterPluginRegistry PluginRegistry { get; }

		// @property (readonly, getter = isDisplayingFlutterUI, nonatomic) BOOL displayingFlutterUI;
		[Export ("displayingFlutterUI")]
		bool DisplayingFlutterUI { [Bind ("isDisplayingFlutterUI")] get; }

		// @property (nonatomic, strong) UIView * _Nonnull splashScreenView;
		[Export ("splashScreenView", ArgumentSemantic.Strong)]
		UIView SplashScreenView { get; set; }

		// -(BOOL)loadDefaultSplashScreenView;
		[Export("loadDefaultSplashScreenView")]
		bool LoadDefaultSplashScreenView();

		// @property (getter = isViewOpaque, nonatomic) BOOL viewOpaque;
		[Export ("viewOpaque")]
		bool ViewOpaque { [Bind ("isViewOpaque")] get; set; }

		// @property (readonly, nonatomic, weak) FlutterEngine * _Nullable engine;
		[NullAllowed, Export ("engine", ArgumentSemantic.Weak)]
		FlutterEngine Engine { get; }

		// @property (readonly, nonatomic) NSObject<FlutterBinaryMessenger> * _Nonnull binaryMessenger;
		[Export ("binaryMessenger")]
		IFlutterBinaryMessenger BinaryMessenger { get; }

		// @property (readonly, nonatomic) BOOL engineAllowHeadlessExecution;
		[Export ("engineAllowHeadlessExecution")]
		bool EngineAllowHeadlessExecution { get; }
	}
}
