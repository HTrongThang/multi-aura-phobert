// Code generated by protoc-gen-go. DO NOT EDIT.
// versions:
// 	protoc-gen-go v1.35.2
// 	protoc        v5.29.0
// source: toxicity.proto

package toxicity

import (
	protoreflect "google.golang.org/protobuf/reflect/protoreflect"
	protoimpl "google.golang.org/protobuf/runtime/protoimpl"
	reflect "reflect"
	sync "sync"
)

const (
	// Verify that this generated code is sufficiently up-to-date.
	_ = protoimpl.EnforceVersion(20 - protoimpl.MinVersion)
	// Verify that runtime/protoimpl is sufficiently up-to-date.
	_ = protoimpl.EnforceVersion(protoimpl.MaxVersion - 20)
)

type AnalyzeRequest struct {
	state         protoimpl.MessageState
	sizeCache     protoimpl.SizeCache
	unknownFields protoimpl.UnknownFields

	Text string `protobuf:"bytes,1,opt,name=text,proto3" json:"text,omitempty"`
}

func (x *AnalyzeRequest) Reset() {
	*x = AnalyzeRequest{}
	mi := &file_toxicity_proto_msgTypes[0]
	ms := protoimpl.X.MessageStateOf(protoimpl.Pointer(x))
	ms.StoreMessageInfo(mi)
}

func (x *AnalyzeRequest) String() string {
	return protoimpl.X.MessageStringOf(x)
}

func (*AnalyzeRequest) ProtoMessage() {}

func (x *AnalyzeRequest) ProtoReflect() protoreflect.Message {
	mi := &file_toxicity_proto_msgTypes[0]
	if x != nil {
		ms := protoimpl.X.MessageStateOf(protoimpl.Pointer(x))
		if ms.LoadMessageInfo() == nil {
			ms.StoreMessageInfo(mi)
		}
		return ms
	}
	return mi.MessageOf(x)
}

// Deprecated: Use AnalyzeRequest.ProtoReflect.Descriptor instead.
func (*AnalyzeRequest) Descriptor() ([]byte, []int) {
	return file_toxicity_proto_rawDescGZIP(), []int{0}
}

func (x *AnalyzeRequest) GetText() string {
	if x != nil {
		return x.Text
	}
	return ""
}

type AnalyzeResponse struct {
	state         protoimpl.MessageState
	sizeCache     protoimpl.SizeCache
	unknownFields protoimpl.UnknownFields

	ToxicityScore float64 `protobuf:"fixed64,1,opt,name=toxicity_score,json=toxicityScore,proto3" json:"toxicity_score,omitempty"`
}

func (x *AnalyzeResponse) Reset() {
	*x = AnalyzeResponse{}
	mi := &file_toxicity_proto_msgTypes[1]
	ms := protoimpl.X.MessageStateOf(protoimpl.Pointer(x))
	ms.StoreMessageInfo(mi)
}

func (x *AnalyzeResponse) String() string {
	return protoimpl.X.MessageStringOf(x)
}

func (*AnalyzeResponse) ProtoMessage() {}

func (x *AnalyzeResponse) ProtoReflect() protoreflect.Message {
	mi := &file_toxicity_proto_msgTypes[1]
	if x != nil {
		ms := protoimpl.X.MessageStateOf(protoimpl.Pointer(x))
		if ms.LoadMessageInfo() == nil {
			ms.StoreMessageInfo(mi)
		}
		return ms
	}
	return mi.MessageOf(x)
}

// Deprecated: Use AnalyzeResponse.ProtoReflect.Descriptor instead.
func (*AnalyzeResponse) Descriptor() ([]byte, []int) {
	return file_toxicity_proto_rawDescGZIP(), []int{1}
}

func (x *AnalyzeResponse) GetToxicityScore() float64 {
	if x != nil {
		return x.ToxicityScore
	}
	return 0
}

var File_toxicity_proto protoreflect.FileDescriptor

var file_toxicity_proto_rawDesc = []byte{
	0x0a, 0x0e, 0x74, 0x6f, 0x78, 0x69, 0x63, 0x69, 0x74, 0x79, 0x2e, 0x70, 0x72, 0x6f, 0x74, 0x6f,
	0x12, 0x08, 0x74, 0x6f, 0x78, 0x69, 0x63, 0x69, 0x74, 0x79, 0x22, 0x24, 0x0a, 0x0e, 0x41, 0x6e,
	0x61, 0x6c, 0x79, 0x7a, 0x65, 0x52, 0x65, 0x71, 0x75, 0x65, 0x73, 0x74, 0x12, 0x12, 0x0a, 0x04,
	0x74, 0x65, 0x78, 0x74, 0x18, 0x01, 0x20, 0x01, 0x28, 0x09, 0x52, 0x04, 0x74, 0x65, 0x78, 0x74,
	0x22, 0x38, 0x0a, 0x0f, 0x41, 0x6e, 0x61, 0x6c, 0x79, 0x7a, 0x65, 0x52, 0x65, 0x73, 0x70, 0x6f,
	0x6e, 0x73, 0x65, 0x12, 0x25, 0x0a, 0x0e, 0x74, 0x6f, 0x78, 0x69, 0x63, 0x69, 0x74, 0x79, 0x5f,
	0x73, 0x63, 0x6f, 0x72, 0x65, 0x18, 0x01, 0x20, 0x01, 0x28, 0x01, 0x52, 0x0d, 0x74, 0x6f, 0x78,
	0x69, 0x63, 0x69, 0x74, 0x79, 0x53, 0x63, 0x6f, 0x72, 0x65, 0x32, 0x55, 0x0a, 0x0f, 0x54, 0x6f,
	0x78, 0x69, 0x63, 0x69, 0x74, 0x79, 0x53, 0x65, 0x72, 0x76, 0x69, 0x63, 0x65, 0x12, 0x42, 0x0a,
	0x0b, 0x41, 0x6e, 0x61, 0x6c, 0x79, 0x7a, 0x65, 0x54, 0x65, 0x78, 0x74, 0x12, 0x18, 0x2e, 0x74,
	0x6f, 0x78, 0x69, 0x63, 0x69, 0x74, 0x79, 0x2e, 0x41, 0x6e, 0x61, 0x6c, 0x79, 0x7a, 0x65, 0x52,
	0x65, 0x71, 0x75, 0x65, 0x73, 0x74, 0x1a, 0x19, 0x2e, 0x74, 0x6f, 0x78, 0x69, 0x63, 0x69, 0x74,
	0x79, 0x2e, 0x41, 0x6e, 0x61, 0x6c, 0x79, 0x7a, 0x65, 0x52, 0x65, 0x73, 0x70, 0x6f, 0x6e, 0x73,
	0x65, 0x42, 0x14, 0x5a, 0x12, 0x6d, 0x75, 0x6c, 0x74, 0x69, 0x61, 0x75, 0x72, 0x61, 0x2f, 0x74,
	0x6f, 0x78, 0x69, 0x63, 0x69, 0x74, 0x79, 0x62, 0x06, 0x70, 0x72, 0x6f, 0x74, 0x6f, 0x33,
}

var (
	file_toxicity_proto_rawDescOnce sync.Once
	file_toxicity_proto_rawDescData = file_toxicity_proto_rawDesc
)

func file_toxicity_proto_rawDescGZIP() []byte {
	file_toxicity_proto_rawDescOnce.Do(func() {
		file_toxicity_proto_rawDescData = protoimpl.X.CompressGZIP(file_toxicity_proto_rawDescData)
	})
	return file_toxicity_proto_rawDescData
}

var file_toxicity_proto_msgTypes = make([]protoimpl.MessageInfo, 2)
var file_toxicity_proto_goTypes = []any{
	(*AnalyzeRequest)(nil),  // 0: toxicity.AnalyzeRequest
	(*AnalyzeResponse)(nil), // 1: toxicity.AnalyzeResponse
}
var file_toxicity_proto_depIdxs = []int32{
	0, // 0: toxicity.ToxicityService.AnalyzeText:input_type -> toxicity.AnalyzeRequest
	1, // 1: toxicity.ToxicityService.AnalyzeText:output_type -> toxicity.AnalyzeResponse
	1, // [1:2] is the sub-list for method output_type
	0, // [0:1] is the sub-list for method input_type
	0, // [0:0] is the sub-list for extension type_name
	0, // [0:0] is the sub-list for extension extendee
	0, // [0:0] is the sub-list for field type_name
}

func init() { file_toxicity_proto_init() }
func file_toxicity_proto_init() {
	if File_toxicity_proto != nil {
		return
	}
	type x struct{}
	out := protoimpl.TypeBuilder{
		File: protoimpl.DescBuilder{
			GoPackagePath: reflect.TypeOf(x{}).PkgPath(),
			RawDescriptor: file_toxicity_proto_rawDesc,
			NumEnums:      0,
			NumMessages:   2,
			NumExtensions: 0,
			NumServices:   1,
		},
		GoTypes:           file_toxicity_proto_goTypes,
		DependencyIndexes: file_toxicity_proto_depIdxs,
		MessageInfos:      file_toxicity_proto_msgTypes,
	}.Build()
	File_toxicity_proto = out.File
	file_toxicity_proto_rawDesc = nil
	file_toxicity_proto_goTypes = nil
	file_toxicity_proto_depIdxs = nil
}
