# Quản lý Packages (Thư viện Unity)

Thư mục này quản lý toàn bộ các gói thư viện phụ thuộc của Unity Package Manager (UPM) cho dự án **Bloodfiend**.

---

## 1. Các Package Cốt lõi Đã Cài đặt (`manifest.json`)

* **Universal Render Pipeline (`com.unity.render-pipelines.universal`):** Phiên bản `17.3.0`. Cung cấp pipeline 2D Renderer, nguồn sáng động 2D (`Light2D`), normal maps và cơ chế bóng đổ (`Shadow Caster 2D`).
* **Input System (`com.unity.inputsystem`):** Phiên bản `1.19.0`. Hệ thống điều khiển đa nền tảng hiện đại (Bàn phím, chuột, tay cầm gamepad).
* **2D Tilemap Extras (`com.unity.2d.tilemap.extras`):** Cung cấp Rule Tiles để tự động ghép mép tường và sàn biệt thự nhanh chóng.
* **Aseprite & PSD Importers (`com.unity.2d.aseprite`, `com.unity.2d.psdimporter`):** Cho phép Artist lưu thẳng file gốc từ Aseprite hoặc Photoshop vào Unity mà không cần xuất thủ công ra từng file PNG.
* **Visual Studio Editor (`com.unity.ide.visualstudio`):** Phiên bản `2.0.26`. Cầu nối đồng bộ code giữa Unity và VS Code / Visual Studio cho gợi ý code C# (IntelliSense).

---

## 2. Quy tắc Quản lý Package

* Luôn dùng giao diện **Window > Package Manager** trong Unity để cài đặt, cập nhật hoặc xóa package.
* Tránh sửa file `manifest.json` bằng tay trừ khi cần xử lý merge conflict trên Git.
* File `packages-lock.json` có nhiệm vụ chốt cứng phiên bản để mọi thành viên trong team khi mở máy đều tải đúng phiên bản thư viện giống hệt nhau.
