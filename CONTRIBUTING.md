# Quy chuẩn Đóng góp & Phát triển Dự án (Contributing Guidelines)

Tài liệu này đưa ra các quy tắc và hướng dẫn phối hợp làm việc nhóm cho dự án **Bloodfiend - Huyết Quỷ** nhằm đảm bảo mã nguồn sạch sẽ, tránh xung đột file (merge conflict) và tối ưu hóa hiệu suất làm việc giữa các team (Dev, Art, Audio, Game Design).

---

## 1. Chiến lược Phân nhánh Git (Branching Strategy)

Dự án áp dụng mô hình phân nhánh chuẩn **Git Flow / Feature Branching**:

* **`main`**: Nhánh phát hành (Production). Luôn ở trạng thái ổn định, đã qua kiểm thử, sẵn sàng xuất build chơi thử nghiệm.
* **`develop`**: Nhánh tích hợp chính của cả team. Mọi tính năng sau khi hoàn thiện sẽ được merge vào đây.
* **`feat/<tên-tính-năng>`**: Nhánh phát triển tính năng mới.
  * *Ví dụ:* `feat/player-movement`, `feat/flashlight-mechanic`, `feat/inventory-grid`, `feat/puzzle-lockpick`.
* **`fix/<tên-lỗi>`**: Nhánh sửa lỗi từ nhánh `develop`.
  * *Ví dụ:* `fix/door-key-nullref`, `fix/flashlight-battery-drain`.
* **`art/<tên-asset>`** hoặc **`audio/<tên-sfx>`**: Nhánh import asset cho Art / Audio team.

### Quy trình tạo branch:
1. Luôn kéo mã nguồn mới nhất từ `develop` trước khi tạo branch mới:
   ```bash
   git checkout develop
   git pull origin develop
   git checkout -b feat/ten-tinh-nang
   ```
2. Thường xuyên rebase hoặc merge từ `develop` vào nhánh cá nhân để xử lý conflict sớm.

---

## 2. Quy ước Đặt tên Commit (Conventional Commits)

Format chuẩn:
```text
<loại-thay-đổi>(<phạm-vi>): <mô tả ngắn gọn bằng tiếng Việt hoặc tiếng Anh>
```

### Các tiền tố (Types):
* **`feat`**: Tính năng mới cho gameplay, mechanics, UI.
* **`fix`**: Sửa lỗi bug, crash, logic sai.
* **`art`**: Thêm/cập nhật sprite, animation, tileset, material.
* **`audio`**: Thêm/cập nhật SFX, BGM, AudioMixer.
* **`refactor`**: Cấu trúc lại code mà không thay đổi logic gameplay.
* **`perf`**: Tối ưu hóa hiệu năng (Draw Calls, GC Alloc, CPU/GPU spike).
* **`docs`**: Cập nhật tài liệu (GDD, README, kịch bản).
* **`chore`**: Cập nhật package, settings Unity, file cấu hình `.gitignore`.

### Ví dụ:
* `feat(player): thêm cơ chế đi lén lút và tiếng bước chân`
* `feat(light): thiết lập đèn pin tiêu hao pin theo thời gian`
* `fix(puzzle): sửa lỗi nhặt chìa khóa không cập nhật inventory`
* `art(enemy): cập nhật sprite sheet di chuyển cho Speedster`

---

## 3. Quy tắc Vàng khi làm việc với Unity theo Team

Merge conflict trên các file nhị phân và file YAML của Unity (Scene, Prefab) là nguyên nhân hàng đầu gây hỏng dự án. Vui lòng tuân thủ nghiêm ngặt các điều sau:

### a. Làm việc với Scene & Prefab
1. **Không sửa chung một Scene chính cùng lúc:**
   * Mỗi lập trình viên nên tạo một scene thử nghiệm cá nhân trong `Assets/_Project/Scenes/Sandboxes/<TênDev>/` để test mechanic.
   * Khi hoàn thiện, gói toàn bộ logic/mô hình thành **Prefab** rồi mới gắn vào Scene chính.
2. **Sử dụng Prefab Mode:** Khi chỉnh sửa quái vật, người chơi, vật phẩm, hãy mở thẳng Prefab Mode để sửa thay vì sửa trực tiếp trên Scene.
3. **Additive Scene:** Đối với các màn chơi phức tạp, level sẽ được chia thành nhiều sub-scene (ví dụ: `Mansion_Environment`, `Mansion_Lighting`, `Mansion_Gameplay`) để Level Designer và Gameplay Programmer có thể làm việc song song.

### b. Quản lý File Meta (`.meta`)
* Mọi thao tác **Tạo mới, Đổi tên, Di chuyển, Xóa** asset ĐỀU PHẢI THỰC HIỆN BÊN TRONG UNITY EDITOR.
* **Tuyệt đối không xóa file `.meta`** của asset đang tồn tại. Xóa `.meta` sẽ làm thay đổi GUID và khiến toàn bộ tham chiếu (Missing Reference) trên Scene/Prefab bị gãy.
* Khi commit code, **luôn kiểm tra xem file `.meta` đi kèm đã được stage cùng với asset chưa**.

### c. Thiết lập Editor chuẩn
* Bật chế độ Force Text: `Edit > Project Settings > Editor > Asset Serialization > Mode: Force Text`.
* Đảm bảo Git LFS hoạt động tốt trước khi commit các asset đồ họa (PNG, PSD), âm thanh (WAV, MP3) hoặc video.

---

## 4. Quy chuẩn Viết Code C# (Coding Standards)

Dự án hướng đến kiến trúc tách lớp sạch sẽ (Clean Architecture / MVP / Event-Driven):

### a. Đặt tên (Naming Conventions)
* **PascalCase**: Tên Class, Struct, Enum, Interface, Method, Public Property.
  ```csharp
  public class FlashlightController : MonoBehaviour
  {
      public float CurrentBattery { get; private set; }
      public void ToggleFlashlight() { }
  }
  ```
* **camelCase**: Tên biến cục bộ, tham số hàm.
  ```csharp
  public void TakeDamage(float damageAmount)
  {
      float finalDamage = damageAmount;
  }
  ```
* **`_camelCase`** (dấu gạch dưới phía trước): Các trường dữ liệu `private` hoặc `protected`, bao gồm cả biến serialize trong Unity Inspector:
  ```csharp
  [SerializeField] private float _maxBatteryLife = 100f;
  private bool _isTurnedOn;
  ```
* **Tiền tố `I` cho Interface**: `IInteractable`, `IDamageable`, `ISavable`.

### b. Kiến trúc & Hiệu năng
* **Assembly Definitions (`.asmdef`):** Đặt code đúng thư mục module tương ứng (`Core`, `Gameplay`, `Interaction`, `UI`). Tránh tạo quan hệ phụ thuộc vòng tròn (Circular Dependency).
* **Tách biệt Logic và Hiển thị:**
  * Logic tính toán máu, thời lượng pin, kho đồ nên là C# thuần (POCO - Plain Old C# Objects) hoặc ScriptableObject.
  * `MonoBehaviour` chỉ nên đóng vai trò là View/Presenter kết nối hiển thị với màn hình và xử lý Input/Animation.
* **Hạn chế Garbage Collection (GC Alloc):**
  * Không dùng `GetComponent` hoặc `FindObjectOfType` liên tục trong hàm `Update()`. Cache lại trong `Awake()` hoặc `Start()`.
  * Tránh cấp phát bộ nhớ liên tục (hạn chế `new List()`, `new string` không cần thiết) trong vòng lặp mỗi frame.

---

## 5. Quy trình Tạo Pull Request (PR)

1. Tự kiểm tra lại các thay đổi bằng `git status` và `git diff`.
2. Đảm bảo Unity Editor trên máy cá nhân biên dịch sạch sẽ, **0 lỗi (Error)** và không có script bị **Missing Reference**.
3. Push branch lên remote:
   ```bash
   git push origin feat/ten-tinh-nang
   ```
4. Tạo Pull Request trên GitHub/GitLab vào nhánh `develop`.
5. Điền đầy đủ mô tả PR:
   * **Mục tiêu:** Tính năng này giải quyết vấn đề gì?
   * **Cách kiểm thử (Testing Steps):** Mở scene nào? Bấm phím gì? Kết quả mong đợi là gì?
6. Yêu cầu ít nhất **1 thành viên khác (Peer Review)** kiểm tra code và phê duyệt (Approve) trước khi merge.

