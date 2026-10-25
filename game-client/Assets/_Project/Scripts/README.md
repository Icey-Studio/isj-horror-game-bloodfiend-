# Kiến trúc Mã nguồn C# & Quy chuẩn Lập trình

Thư mục này chứa toàn bộ mã nguồn C# của **Bloodfiend**, được phân chia theo 4 module Assembly Definition (`.asmdef`) độc lập.

---

## 1. Phân chia 4 Module Assembly

```text
Scripts/
├── Core/
│   ├── Core.asmdef                      # Assembly: Bloodfiend.Core (Nền tảng hệ thống)
│   └── NoiseManager.cs                  # Hệ thống phát và lắng nghe tiếng động cho AI
├── Gameplay/
│   ├── Gameplay.asmdef                  # Assembly: Bloodfiend.Gameplay (Di chuyển, Đèn pin, AI)
│   ├── PlayerController.cs              # Di chuyển 8 hướng, thể lực, chạy nhanh
│   └── FlashlightController.cs          # Đèn pin 2 mức sáng, tiêu hao pin
├── Interaction/
│   ├── Interaction.asmdef               # Assembly: Bloodfiend.Interaction (Tương tác, Giải đố)
│   ├── IInteractable.cs                 # Interface chuẩn cho vật thể tương tác
│   └── CurtainInteractable.cs           # Kéo rèm cửa sổ đón ánh nắng tạo vùng an toàn
└── UI/
    └── UI.asmdef                        # Assembly: Bloodfiend.UI (Giao diện HUD, Menu, Đọc Note)
```

### Trách nhiệm của từng Module:
* **`Bloodfiend.Core`:** Nền tảng độc lập, quản lý hệ thống phát tiếng ồn `NoiseManager`, các kênh sự kiện (Event Channels). Không phụ thuộc vào bất kỳ module nào khác.
* **`Bloodfiend.Gameplay`:** Xử lý điều khiển người chơi An, cơ chế đèn pin 2 mức sáng, vũ khí, sát thương và máy trạng thái AI của quái vật. Phụ thuộc `Core`, `InputSystem` và `URP Runtime`.
* **`Bloodfiend.Interaction`:** Các cơ chế tương tác môi trường (rèm cửa, cửa khóa, thẻ từ K3/K4, câu đố). Phụ thuộc `Core` và `Gameplay`.
* **`Bloodfiend.UI`:** Toàn bộ hiển thị màn hình (thanh máu, pin đèn, số đạn, cửa sổ đọc tài liệu ghi chép). Phụ thuộc `Core`, `Gameplay`, `Interaction` và `TextMeshPro`.

---

## 2. Quy ước Viết Code (Coding Conventions)

* **Namespace:** Đặt đúng theo cấu trúc thư mục con:
  ```csharp
  namespace Bloodfiend.Gameplay { ... }
  namespace Bloodfiend.Interaction { ... }
  ```
* **Quy chuẩn Đặt tên:**
  * **PascalCase:** Class, Struct, Enum, Interface, Method, Public Property (`PlayerController`, `MaxBattery`, `TakeDamage()`).
  * **camelCase:** Biến cục bộ, tham số truyền vào hàm (`moveInput`, `damageAmount`).
  * **`_camelCase` (dấu gạch dưới phía trước):** Biến `private` và `protected`, bao gồm cả biến serialize trong Inspector:
    ```csharp
    [SerializeField] private float _walkSpeed = 3.5f;
    private bool _isSprinting;
    ```
  * **Tiền tố `I` cho Interface:** `IInteractable`, `IDamageable`.

---

## 3. Tối ưu Hiệu năng (Performance Best Practices)

1. **Hạn chế Garbage Collection (GC Alloc) trong vòng lặp:**
   * Không cấp phát bộ nhớ mới (`new List()`, `new string`) trong các hàm chạy mỗi frame như `Update()` hoặc `FixedUpdate()`.
   * Luôn cache lại kết quả của `GetComponent<T>()` trong `Awake()` hoặc `Start()`.
2. **Giao tiếp Tách rời (Event-Driven):**
   * Sử dụng C# `event Action` để bắn tín hiệu giữa các module (ví dụ: khi pin đèn thay đổi, bắn event để UI tự cập nhật thanh trượt, không để script đèn pin gọi trực tiếp vào UI).
3. **Vật lý Unity 6:**
   * Khi cập nhật vận tốc cho nhân vật 2D, sử dụng thuộc tính mới `Rigidbody2D.linearVelocity` (thay vì thuộc tính cũ `velocity`).

