using System.Collections.Generic;
using JsonTester.Models;

namespace JsonTester.ViewModels;

public class PresetSidebarViewModel: ViewModelBase
{
    public List<ConnectionPreset> Presets { get; } =
    [
        new() { Name = "로그인 요청", Addr = "192.168.1.10:9000", ConnectionType = ConnectionType.Http },
        new() { Name = "디바이스 상태 조회", Addr = "ws://device.local:8081", ConnectionType = ConnectionType.WS },
        new() { Name = "센서값 업로드", Addr = "https://api.example.com/v1/sensors:443", ConnectionType = ConnectionType.Http }
    ];
}