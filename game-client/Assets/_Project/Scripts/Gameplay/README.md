# Module `Bloodfiend.Gameplay` Assembly

Thư mục này chịu trách nhiệm xử lý toàn bộ logic gameplay, cơ chế di chuyển, chiến đấu và hành vi của quái vật cho **Bloodfiend**. Được quản lý bởi `Gameplay.asmdef`.

---

## 1. Phạm vi & Trách nhiệm

Module này quyết định trải nghiệm chơi của game:
* **Điều khiển Nhân vật (`PlayerController.cs`):** Di chuyển 8 hướng góc nhìn Topdown, quản lý thể lực (Stamina), chế độ đi lén lút vs chạy nhanh, tự xoay mặt theo con trỏ chuột.
* **Cơ chế Sinh tồn bằng Ánh sáng (`FlashlightController.cs`):**
  * *Chế độ Thường (Low Power):* Tiêu hao ít pin, dùng để soi đường đi trong bóng tối.
  * *Chế độ Công suất cao (High Power):* Hao pin nhanh, góc quét rộng hơn, kích hoạt collider làm choáng quái vật và chặn khả năng tự hồi phục của *Regenerator*.
* **Vũ khí & Chiến đấu:** Đòn đánh cận chiến (Dao, Machete), cơ chế bắn súng raycast (Súng lục, Shotgun), quản lý số lượng đạn.
* **AI Quái vật (Máy trạng thái FSM):**
  * *Quái thường / Shipper biến đổi:* Đi tuần, đuổi theo cắn xé khi thấy người.
  * *Speedster:* Bị mù, di chuyển cực nhanh dựa hoàn toàn vào việc lắng nghe sự kiện từ `NoiseManager`.
  * *Regenerator (Dì Hạnh):* Liên tục hồi phục máu trừ khi bị chiếu ánh sáng mạnh hoặc bị dụ vào vệt nắng.
  * *Bosses:* Boss Bình (xúc tu & tắt 4 đèn pha), Boss Chi (phun axit, bay lượn và gọi bầy).

---

## 2. Quy chuẩn Namespace & Phụ thuộc

Toàn bộ script trong thư mục này dùng namespace:
```csharp
namespace Bloodfiend.Gameplay
{
    // Nội dung code
}
```

* **Các Module được phép Tham chiếu:**
  * `Bloodfiend.Core`
  * `Unity.InputSystem`
  * `Unity.RenderPipelines.Universal.Runtime` (để điều khiển `Light2D`)
* **Điều cấm kỵ:**
  * Không được tham chiếu trực tiếp đến `Bloodfiend.UI`. Khi nhân vật mất máu hay pin đèn giảm, hãy bắn sự kiện (Event) để UI tự lắng nghe và cập nhật.
