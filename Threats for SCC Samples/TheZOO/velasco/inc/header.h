 unsigned char headercontent[]=
 {
  0x91,0x55,0x00,0x10,0x12,0x3a,0x00,0x10,0x19,0x04,0x00,0x10,0x20,
  0xc4,0x1b,0xee,
  0x00,0x00,       // Estes dois bytes serao substituidos pelo CRC16
  0x01,0x00,0x03,0x00,0x01,0x00,0x00,0x00,
  0x00,0x00,0x21,0x00,0x00,0x00,0xc8,0x00,0x00,0x00,0x09,0x00,0x00,
  0x00,0x01,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x64,0x00,0x00,0x00,
  0x66,0x00,0x00,0x00,0xf6,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x0a,
  0x01,0x00,0x00,0x00,0x00,0x00,0x00,0x0a,0x01,0x00,0x00,0x00,0x00,
  0x00,0x00,0x76,0x2d,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
  0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x01,0x00,0x00,0x00,
  0x00,0x00,0x03,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x7a,0x00,0x00,
  0x00,0x12,0x01,0x00,0x00,0x44,0x00,0x00,0x00,0x8c,0x01,0x00,0x00,
  0xbc,0x24,0x00,0x00,0x78,0x03,0x00,0x00,0xbc,0x24,0x00,0x00,0x00,
  0x00,0x00,0x00,0xd0,0x01,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
  0x00,0x00,0x00,0x00,0x00,0x00,0x78,0x00,0x00,0x00,0xd0,0x01,0x00,
  0x00,0x42,0x00,0x00,0x00,0x48,0x02,0x00,0x00,0xa8,0x08,0x00,0x00,
  0x34,0x28,0x00,0x00,0xa8,0x08,0x00,0x00,0x00,0x00,0x00,0x00,0x8a,
  0x02,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
  0x00,0x00,0x7a,0x00,0x00,0x00,0x8a,0x02,0x00,0x00,0x44,0x00,0x00,
  0x00,0x04,0x03,0x00,0x00,0x12,0x00,0x00,0x00,0xdc,0x30,0x00,0x00,
  0x12,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x48,0x03,0x00,0x00,0x88,
  0x6f,0x1f,0x10,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x22,0x00,
  0x00,0x00,0x48,0x03,0x00,0x00,0x0e,0x00,0x00,0x00,0x6a,0x03,0x00,
  0x00,0x43,0x00,0x3a,0x00,0x5c,0x00,0x53,0x00,0x79,0x00,0x6d,0x00,
  0x62,0x00,0x69,0x00,0x61,0x00,0x6e,0x00,0x5c,0x00,0x36,0x00,0x2e,
  0x00,0x31,0x00,0x5c,0x00,0x53,0x00,0x65,0x00,0x72,0x00,0x69,0x00,
  0x65,0x00,0x73,0x00,0x36,0x00,0x30,0x00,0x5c,0x00,0x45,0x00,0x70,
  0x00,0x6f,0x00,0x63,0x00,0x33,0x00,0x32,0x00,0x5c,0x00,0x72,0x00,
  0x65,0x00,0x6c,0x00,0x65,0x00,0x61,0x00,0x73,0x00,0x65,0x00,0x5c,
  0x00,0x74,0x00,0x68,0x00,0x75,0x00,0x6d,0x00,0x62,0x00,0x5c,0x00,
  0x75,0x00,0x72,0x00,0x65,0x00,0x6c,0x00,0x5c,0x00,0x76,0x00,0x65,
  0x00,0x6c,0x00,0x61,0x00,0x73,0x00,0x63,0x00,0x6f,0x00,0x2e,0x00,
  0x61,0x00,0x70,0x00,0x70,0x00,0x21,0x00,0x3a,0x00,0x5c,0x00,0x73,
  0x00,0x79,0x00,0x73,0x00,0x74,0x00,0x65,0x00,0x6d,0x00,0x5c,0x00,
  0x61,0x00,0x70,0x00,0x70,0x00,0x73,0x00,0x5c,0x00,0x76,0x00,0x65,
  0x00,0x6c,0x00,0x61,0x00,0x73,0x00,0x63,0x00,0x6f,0x00,0x5c,0x00,
  0x76,0x00,0x65,0x00,0x6c,0x00,0x61,0x00,0x73,0x00,0x63,0x00,0x6f,
  0x00,0x2e,0x00,0x61,0x00,0x70,0x00,0x70,0x00,0x43,0x00,0x3a,0x00,
  0x5c,0x00,0x53,0x00,0x79,0x00,0x6d,0x00,0x62,0x00,0x69,0x00,0x61,
  0x00,0x6e,0x00,0x5c,0x00,0x36,0x00,0x2e,0x00,0x31,0x00,0x5c,0x00,
  0x53,0x00,0x65,0x00,0x72,0x00,0x69,0x00,0x65,0x00,0x73,0x00,0x36,
  0x00,0x30,0x00,0x5c,0x00,0x45,0x00,0x70,0x00,0x6f,0x00,0x63,0x00,
  0x33,0x00,0x32,0x00,0x5c,0x00,0x72,0x00,0x65,0x00,0x6c,0x00,0x65,
  0x00,0x61,0x00,0x73,0x00,0x65,0x00,0x5c,0x00,0x74,0x00,0x68,0x00,
  0x75,0x00,0x6d,0x00,0x62,0x00,0x5c,0x00,0x75,0x00,0x72,0x00,0x65,
  0x00,0x6c,0x00,0x5c,0x00,0x6d,0x00,0x61,0x00,0x72,0x00,0x63,0x00,
  0x6f,0x00,0x73,0x00,0x2e,0x00,0x6d,0x00,0x64,0x00,0x6c,0x00,0x21,
  0x00,0x3a,0x00,0x5c,0x00,0x73,0x00,0x79,0x00,0x73,0x00,0x74,0x00,
  0x65,0x00,0x6d,0x00,0x5c,0x00,0x61,0x00,0x70,0x00,0x70,0x00,0x73,
  0x00,0x5c,0x00,0x76,0x00,0x65,0x00,0x6c,0x00,0x61,0x00,0x73,0x00,
  0x63,0x00,0x6f,0x00,0x5c,0x00,0x6d,0x00,0x61,0x00,0x72,0x00,0x63,
  0x00,0x6f,0x00,0x73,0x00,0x2e,0x00,0x6d,0x00,0x64,0x00,0x6c,0x00,
  0x43,0x00,0x3a,0x00,0x5c,0x00,0x53,0x00,0x79,0x00,0x6d,0x00,0x62,
  0x00,0x69,0x00,0x61,0x00,0x6e,0x00,0x5c,0x00,0x36,0x00,0x2e,0x00,
  0x31,0x00,0x5c,0x00,0x53,0x00,0x65,0x00,0x72,0x00,0x69,0x00,0x65,
  0x00,0x73,0x00,0x36,0x00,0x30,0x00,0x5c,0x00,0x45,0x00,0x70,0x00,
  0x6f,0x00,0x63,0x00,0x33,0x00,0x32,0x00,0x5c,0x00,0x72,0x00,0x65,
  0x00,0x6c,0x00,0x65,0x00,0x61,0x00,0x73,0x00,0x65,0x00,0x5c,0x00,
  0x74,0x00,0x68,0x00,0x75,0x00,0x6d,0x00,0x62,0x00,0x5c,0x00,0x75,
  0x00,0x72,0x00,0x65,0x00,0x6c,0x00,0x5c,0x00,0x76,0x00,0x65,0x00,
  0x6c,0x00,0x61,0x00,0x73,0x00,0x63,0x00,0x6f,0x00,0x2e,0x00,0x72,
  0x00,0x73,0x00,0x63,0x00,0x21,0x00,0x3a,0x00,0x5c,0x00,0x73,0x00,
  0x79,0x00,0x73,0x00,0x74,0x00,0x65,0x00,0x6d,0x00,0x5c,0x00,0x61,
  0x00,0x70,0x00,0x70,0x00,0x73,0x00,0x5c,0x00,0x76,0x00,0x65,0x00,
  0x6c,0x00,0x61,0x00,0x73,0x00,0x63,0x00,0x6f,0x00,0x5c,0x00,0x76,
  0x00,0x65,0x00,0x6c,0x00,0x61,0x00,0x73,0x00,0x63,0x00,0x6f,0x00,
  0x2e,0x00,0x72,0x00,0x73,0x00,0x63,0x00,0x53,0x00,0x65,0x00,0x72,
  0x00,0x69,0x00,0x65,0x00,0x73,0x00,0x36,0x00,0x30,0x00,0x50,0x00,
  0x72,0x00,0x6f,0x00,0x64,0x00,0x75,0x00,0x63,0x00,0x74,0x00,0x49,
  0x00,0x44,0x00,0x56,0x00,0x65,0x00,0x6c,0x00,0x61,0x00,0x73,0x00,
  0x63,0x00,0x6f,0x00
 };
