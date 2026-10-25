# Module `Bloodfiend.UI` Assembly

Thư mục này quản lý toàn bộ giao diện người dùng (Canvas, HUD, popups, bảng đọc tài liệu, menu) cho **Bloodfiend**. Được quản lý bởi `UI.asmdef`.

---

## 1. Phạm vi & Trách nhiệm

* **Giao diện Trong Màn chơi (HUD):**
  * Thanh máu (Health Bar) và nhịp tim dao động theo mức độ nguy hiểm.
  * Thanh thể lực (hiển thị khi bắt đầu chạy nhanh).
  * Vạch báo pin đèn pin và icon báo chế độ sáng đang bật (Thường hay Cao).
  * Số lượng đạn còn lại và icon vũ khí đang cầm.
* **Cửa sổ Đọc Tài liệu & Nhật ký:**
  * Khung xem toàn màn hình để người chơi đọc các mẩu giấy nhắn, hồ sơ bệnh án của Chi, băng ghi âm của ông Bình và ảnh tư liệu.
* **Giao diện Kho đồ (Inventory UI):**
  * Ô lưới chứa đồ, tooltip hiển thị thông tin vật phẩm và các nút tương tác (Sử dụng, Ghép đồ, Vứt bỏ).
* **Các Menu Trạng thái:**
  * Menu chính (Main Menu), Cài đặt (Settings), Menu tạm dừng (Pause), Màn hình Kết thúc game (Ending 1 & Ending 2).

---

## 2. Quy chuẩn Namespace & Phụ thuộc

Toàn bộ script trong thư mục này dùng namespace:
```csharp
namespace Bloodfiend.UI
{
    // Nội dung code
}
```

* **Các Module được phép Tham chiếu:**
  * `Bloodfiend.Core`
  * `Bloodfiend.Gameplay`
  * `Bloodfiend.Interaction`
  * `Unity.TextMeshPro`
  * `Unity.InputSystem`

---

## 3. Lời khuyên cho Lập trình viên UI

* **Mô hình MVP (Model - View - Presenter):** Giữ các component UI thuần túy làm nhiệm vụ hiển thị hình ảnh và bắt sự kiện bấm nút. Không nhét logic trừ máu hay trừ đạn vào trong code UI.
* **Canvas Scaler:** Đảm bảo mọi Canvas đều đặt ở chế độ `Scale With Screen Size` (Độ phân giải tham chiếu: `1920x1080`, Match: `0.5`).
* **TextMeshPro:** Bắt buộc sử dụng TextMeshPro (`TMP_Text`) thay cho component `Text` cũ của Unity để font chữ luôn sắc nét.
