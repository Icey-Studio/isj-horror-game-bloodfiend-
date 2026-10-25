# Module `Bloodfiend.Core` Assembly

Thư mục này chứa nền tảng kiến trúc hạ tầng dùng chung cho toàn bộ dự án **Bloodfiend**, được quản lý bởi `Core.asmdef`.

---

## 1. Phạm vi & Trách nhiệm

* **Độc lập Tuyệt đối:** Module này **không được phép tham chiếu** tới `Gameplay`, `Interaction` hay `UI`. Đây là lớp nền tảng dưới cùng của dự án.
* **Các Hệ thống Cốt lõi:**
  * **Hệ thống Âm thanh & Tiếng động (`NoiseManager.cs`):** Kênh phát sự kiện âm thanh toàn cục. Khi người chơi chạy nhanh hoặc nổ súng, hệ thống này sẽ phát sóng âm trong một bán kính nhất định để các quái vật nhạy cảm âm thanh (như *Speedster*) nhận diện và săn lùng.
  * **Kênh Sự kiện (Event Channels):** Cho phép các module giao tiếp với nhau mà không cần biết đối phương là ai.
  * **Singletons & Tiện ích:** Các lớp quản lý tồn tại xuyên màn chơi và các hàm tiện ích toán học 2D.

---

## 2. Quy chuẩn Namespace

Toàn bộ script trong thư mục này bắt buộc phải dùng namespace:
```csharp
namespace Bloodfiend.Core
{
    // Nội dung code
}
```

---

## 3. Lưu ý cho Lập trình viên

* **Không nhồi nhét logic gameplay vào đây:** Không viết code tính máu, thể lực người chơi hay cơ chế quái vật cụ thể tại module này.
* Giữ các component tại đây thật nhẹ nhàng, độc lập và có thể tái sử dụng ở bất kỳ đâu trong game.
