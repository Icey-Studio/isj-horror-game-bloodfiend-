# Quy chuẩn Quản lý Màn chơi (Scenes Guidelines)

Thư mục này quản lý toàn bộ các file Scene (`.unity`) của **Bloodfiend**, được phân chia nhằm hỗ trợ nhiều người cùng làm việc mà không bao giờ bị xung đột mã nguồn (merge conflict).

---

## 1. Cấu trúc Thư mục

```text
Scenes/
├── Core/                # Scene khởi động bền vững (Chứa GameManager, Audio, Không bị hủy khi chuyển map)
├── Gameplay/            # Các màn chơi chính thức của game trong căn biệt thự
└── Sandboxes/           # Sân chơi thử nghiệm cá nhân của từng lập trình viên
```

---

## 2. Phân loại & Vai trò của Từng Scene

* **`Core/` (Scene Bootstrapper):**
  * Scene đầu tiên được nạp khi bật game.
  * Chứa các hệ thống chạy xuyên suốt (`DontDestroyOnLoad`): `AudioManager`, `GameStateManager`, và `NoiseManager`.
* **`Gameplay/` (Các Màn chơi Chính thức):**
  * `Level_01_Mansion_Floor1.unity`: Tầng 1 biệt thự (Phòng Study, Thư viện, Hành lang).
  * `Level_02_Mansion_Floor2.unity`: Tầng 2 biệt thự (Phòng điều trị, phòng Chi, phòng ông Bình).
  * `Level_03_Basement_Lab.unity`: Khu nghiên cứu tầng hầm, Core Lab đấu Boss Bình.
  * `Level_04_Courtyard_Escape.unity`: Sân sau và khu rừng, đấu Boss Chi.
* **`Sandboxes/` (Khu vực Thử nghiệm Cá nhân):**
  * Mỗi thành viên tự tạo một scene riêng để test cơ chế của mình:
    * `Sandbox_MinhPhuc_Movement.unity`
    * `Sandbox_AI_Speedster.unity`
    * `Sandbox_LightingTests.unity`
  * Mọi người thoải mái xóa sửa, thử nghiệm trên scene cá nhân mà không sợ ảnh hưởng đến màn chơi chính thức của team!

---

## 3. Quy tắc Vàng để Tránh Hỏng Scene

1. **Tuyệt đối không nhiều người cùng sửa chung một Scene chính cùng lúc:** File `.unity` là file dữ liệu YAML cực kỳ phức tạp. Nếu 2 người cùng sửa chung 1 scene và push lên Git, việc giải quyết merge conflict gần như chắc chắn sẽ làm gãy các liên kết trong Scene.
2. **Xây dựng Level bằng Prefab:** Level Designer khi dựng phòng hãy dùng các Prefab đã hoàn chỉnh kéo thả vào.
3. **Kỹ thuật Additive Scene Loading:** Đối với các màn chơi lớn, chúng ta sẽ chia thành nhiều sub-scene nạp đè lên nhau (ví dụ: Scene chứa tường/ánh sáng riêng, Scene chứa quái vật/vật phẩm riêng) để Artist và Gameplay Programmer có thể làm việc song song trên cùng một khu vực.
