# `_Project` - Thư mục Gốc Tài nguyên Tự làm

Thư mục này chứa **100%** toàn bộ mã nguồn, hình ảnh, âm thanh, prefab và cấu hình do chính team phát triển **Bloodfiend** tạo ra.

---

## 1. Mục đích của Thư mục này

Trong Unity, các plugin bên thứ 3 (như TextMeshPro, Odin Inspector, DOTween...) hoặc các gói từ Package Manager thường tự động sinh thư mục nằm rải rác ngay tại `Assets/`.

Để tránh lẫn lộn và giữ dự án luôn ngăn nắp:
* **`Assets/_Project/` (Thư mục này):** Dành riêng 100% cho các sản phẩm do team mình làm.
* **`Assets/*` (Các thư mục khác bên ngoài):** Chứa plugin bên ngoài và file cài đặt mặc định của Unity.
* **Tại sao có dấu gạch dưới `_`?** Dấu gạch dưới giúp thư mục này luôn được hệ điều hành và Unity xếp ở **vị trí trên cùng**, mở project ra là thấy ngay.

---

## 2. Cấu trúc các Thư mục Con

* **`Art/`:** Sprite 2D, animation, tileset, material và texture giao diện. Xem [Hướng dẫn Art](Art/README.md).
* **`Audio/`:** Nhạc nền, âm thanh môi trường và SFX định tuyến qua AudioMixer. Xem [Hướng dẫn Audio](Audio/README.md).
* **`Prefabs/`:** Các GameObject hoàn chỉnh gắn sẵn script cho nhân vật, quái vật, câu đố. Xem [Hướng dẫn Prefabs](Prefabs/README.md).
* **`Scenes/`:** Màn chơi chính thức, scene quản lý hệ thống và sân chơi test cá nhân. Xem [Hướng dẫn Scenes](Scenes/README.md).
* **`Scripts/`:** Toàn bộ code C# được phân tách theo Assembly Definition (`.asmdef`). Xem [Hướng dẫn Scripts](Scripts/README.md).

---

## 3. Quy trình Tạo Tính năng Mới cho Thành viên

Khi bắt đầu làm một tính năng mới (ví dụ: một loại bẫy hoặc một loại quái mới), hãy tuân thủ quy trình 4 bước:
1. Viết code logic trong `Scripts/<PhânVùngTươngỨng>/`
2. Import tranh vẽ / sprite vào `Art/<ChuyênMục>/`
3. Ráp code và hình ảnh thành một Prefab hoàn chỉnh trong `Prefabs/<ChuyênMục>/`
4. Mở scene cá nhân trong `Scenes/Sandboxes/` để chạy thử nghiệm độc lập trước khi gắn vào màn chơi chung!
