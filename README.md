# Bloodfiend - Huyết Quỷ 🩸🔦

> **Thể loại:** 2D Topdown, Kinh dị sinh tồn (Survival Horror), Giải đố (Puzzle)  
> **Game Engine:** Unity 6 (`6000.3.19f1`) – Universal Render Pipeline (URP 2D)  
> **Nền tảng mục tiêu:** PC (Windows / macOS)

---

## 📖 Giới thiệu Dự án

**Bloodfiend (Huyết Quỷ)** là tựa game kinh dị sinh tồn góc nhìn từ trên xuống (Top-down 2D). Người chơi vào vai **An** – một cảnh sát vô tình bước vào căn biệt thự u ám sau khi phát hiện một chiếc xe tải khả nghi ven đường. Tại đây, anh phải đối mặt với những sinh vật biến dị khát máu (Huyết Quỷ), vén màn bí ẩn đằng sau các cuộc thí nghiệm bất thường và tìm đường thoát thân cùng những người sống sót.

### 🎮 Cơ chế Gameplay cốt lõi

* **Ánh sáng & Bóng tối (Light & Shadow Survival):**
  * Tận dụng đèn pin (có giới hạn pin) và ánh sáng mặt trời qua các khung rèm cửa để đẩy lùi, làm suy yếu hoặc khắc chế quái vật.
  * Hệ thống đổ bóng 2D (Shadow Caster 2D) tạo các điểm mù nguy hiểm và tình huống jumpscare rùng rợn.
* **Sinh tồn & Quản lý tài nguyên:**
  * Thể lực (Stamina): Di chuyển lén lút (ít tiếng động) vs Chạy nhanh (tiêu tốn thể lực, gây tiếng động thu hút quái vật).
  * Kho đồ (Grid Inventory): Quản lý đạn dược, pin đèn pin, lockpick mở tủ/cửa, bông băng cứu thương.
* **Giải đố môi trường (Environmental Puzzles):**
  * Thu thập ghi chép, tài liệu, mật mã, chìa khóa để mở khóa các khu vực mới trong căn biệt thự nhiều tầng và tầng hầm.
* **Các chủng loài quái vật đa dạng:**
  * *Vampire thường / Shipper biến đổi:* Trâu bò, lao tới tấn công khi nghe thấy tiếng động.
  * *Speedster:* Tốc độ di chuyển cực cao, thoắt ẩn thoắt hiện trong hành lang tối.
  * *Regenerator (Dì Hạnh):* Có khả năng tự hồi máu mạnh mẽ, chỉ có thể khống chế bằng cơ chế ánh sáng đặc thù.
  * *Smoker:* Phun khói độc cản trở tầm nhìn và gây sát thương diện rộng.

---

## 🛠 Công nghệ & Công cụ (Tech Stack)

| Thành phần | Công nghệ / Phiên bản | Ghi chú |
| :--- | :--- | :--- |
| **Engine** | Unity `6000.3.19f1` (Unity 6) | LTS đề xuất |
| **Render Pipeline** | Universal Render Pipeline (URP) | Sử dụng **2D Renderer** (2D Lights, Shadows) |
| **Input System** | New Input System (`com.unity.inputsystem`) | Hỗ trợ Keyboard/Mouse & Gamepad |
| **Camera** | Cinemachine 3.x | Camera follow, screen shake, zoom giải đố |
| **VCS** | Git + **Git LFS** | Quản lý mã nguồn & asset đồ họa/âm thanh nhị phân |
| **Backend & DB** | PostgreSQL, ORM (Tùy chọn) | Dành cho Cloud Save / Leaderboards / Telemetry qua REST API |

---

## 📁 Cấu trúc Thư mục (Source Tree)

Dự án áp dụng quy chuẩn đặt toàn bộ tài nguyên tự phát triển vào `Assets/_Project/` để tránh xung đột với các package bên thứ ba:

```text
Assets/
├── _Project/
│   ├── Art/                     # Sprites, Animations, Materials, UI Graphics
│   │   ├── Sprites/
│   │   ├── Environments/        # Tilesets, Rule Tiles, Decals
│   │   ├── Animations/
│   │   └── Materials/           # 2D Lit Materials, Normal Maps
│   ├── Audio/
│   │   ├── Music/               # Nhạc nền, Ambient rùng rợn
│   │   └── SFX/                 # Tiếng bước chân, tiếng thở, quái vật, súng
│   ├── Prefabs/                 # Player, Enemies, Items, Doors, Puzzles
│   ├── Scenes/
│   │   ├── Core/                # Bootstrapper Scene (Persistent managers)
│   │   ├── Menus/               # MainMenu, PauseMenu, Settings
│   │   └── Gameplay/            # Level_01_Mansion, Level_Basement
│   ├── Scripts/                 # Mã nguồn C# phân theo Assembly Definitions (.asmdef)
│   │   ├── Core/                # Game State, Audio System, Event Channels
│   │   ├── Gameplay/            # Movement, Combat, Flashlight, Health
│   │   ├── Interaction/         # Puzzles, Keys, Doors, Inventory
│   │   └── UI/                  # HUD, Inventory View, Popups
│   └── Settings/                # URP 2D Renderer Data, Input Actions, Preset
├── Plugins/                     # Các thư viện & plugin bên thứ 3 (nếu có)
└── docs/                        # Tài liệu Game Design, Script kịch bản
```

---

## 🚀 Hướng dẫn Cài đặt & Khởi động (Getting Started)

### Yêu cầu trước khi cài đặt:
1. Cài đặt **Unity Hub**.
2. Cài đặt Unity Editor phiên bản **`6000.3.19f1`** (bao gồm module build tương ứng, ví dụ: Windows Build Support).
3. Cài đặt **Git** và **Git LFS** trên máy tính:
   ```bash
   git lfs install
   ```

### Clone và Mở dự án:
1. Clone repository về máy:
   ```bash
   git clone <REPO_URL>
   cd isj-horror-game-bloodfiend-
   ```
2. Đảm bảo toàn bộ asset LFS đã được tải về:
   ```bash
   git lfs pull
   ```
3. Mở **Unity Hub** -> Nhấn **Add** -> Chọn thư mục vừa clone.
4. Chọn đúng phiên bản **Unity 6000.3.19f1** để mở dự án.

---

## 👥 Đóng góp & Quy ước Làm việc

Mọi thành viên trong team vui lòng đọc kỹ tài liệu [CONTRIBUTING.md](CONTRIBUTING.md) trước khi tạo branch hoặc commit code. Các điểm lưu ý hàng đầu:
* Không bao giờ commit đè lên cùng 1 file Scene chính (hãy sử dụng Prefab và Additive Scene).
* Luôn cập nhật `.gitignore` và theo dõi file nặng qua `.gitattributes` (Git LFS).
* Tuân thủ quy chuẩn đặt tên và chia module theo `.asmdef`.

---

## 📄 Bản quyền (License)

Dự án được phân phối dưới giấy phép [MIT License](LICENSE). Xem chi tiết tại file `LICENSE`.

