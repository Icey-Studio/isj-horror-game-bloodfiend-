# Cấu hình Dự án (Project Settings)

Thư mục này chứa toàn bộ các file cấu hình hệ thống toàn cục của Unity cho **Bloodfiend**.

---

## 1. Vai trò của Các File Cấu hình Chính

* **`ProjectVersion.txt`:** Khai báo phiên bản Unity Editor chuẩn: `6000.3.19f1 LTS`.
* **`TagManager.asset`:** Khai báo danh sách các Tag (ví dụ: `Player`, `Enemy`, `Interactable`, `SunlightZone`) và các Physics Layer.
* **`Physics2DSettings.asset`:** Cấu hình ma trận va chạm 2D và cài đặt tia raycast.
* **`QualitySettings.asset` & `URPProjectSettings.asset`:** Cấu hình chất lượng đồ họa, độ phân giải texture và thiết lập URP 2D.
* **`EditorSettings.asset`:** Ép chế độ lưu trữ `Force Text` để các file Scene và Prefab có thể diff và giải quyết xung đột dễ dàng trên Git.

---

## 2. Quy tắc Cộng tác

* **Không tự ý chỉnh sửa:** Không thay đổi các file trong Project Settings khi chưa trao đổi với Lead Developer.
* Khi tạo thêm Physics Layer hoặc Tag mới, hãy báo cho cả team biết để không gây xung đột ma trận va chạm.
