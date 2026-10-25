# Module `Bloodfiend.Interaction` Assembly

Thư mục này quản lý toàn bộ các cơ chế tương tác môi trường, cửa nẻo, khóa thẻ từ, nhặt đồ và hệ thống câu đố cho **Bloodfiend**. Được quản lý bởi `Interaction.asmdef`.

---

## 1. Phạm vi & Trách nhiệm

* **Hợp đồng Tương tác (`IInteractable.cs`):** Định nghĩa interface chuẩn cho bất kỳ vật thể nào người chơi có thể bấm phím `E` để tương tác:
  ```csharp
  public interface IInteractable
  {
      string GetInteractionPrompt(); // Gợi ý hiển thị trên màn hình (vd: "Mở cửa (E)")
      void Interact(GameObject interactor); // Hành động xảy ra khi bấm E
  }
  ```
* **Tương tác Môi trường (`CurtainInteractable.cs`):** Kéo rèm cửa sổ để ánh nắng mặt trời tràn vào phòng, tạo ra khu vực an toàn xua đuổi quái vật.
* **Cửa & Chìa khóa:** Mở khóa bằng thẻ từ (Thẻ K3, K4 dưới tầng hầm), xà beng cạy ván, kìm cắt xích.
* **Hệ thống Câu đố (Puzzles):**
  * Ghép nối ghi chép thư viện để tìm mật mã mở ngăn bàn làm việc ông Bình.
  * Phân phối điện năng hạn chế giữa cửa an ninh và đèn hành lang dưới tầng hầm.
* **Kho đồ & Vật phẩm nhặt được:** Logic nhặt pin đèn pin, đạn dược, bộ sơ cứu, tài liệu ghi chép.

---

## 2. Quy chuẩn Namespace & Phụ thuộc

Toàn bộ script trong thư mục này dùng namespace:
```csharp
namespace Bloodfiend.Interaction
{
    // Nội dung code
}
```

* **Các Module được phép Tham chiếu:**
  * `Bloodfiend.Core`
  * `Bloodfiend.Gameplay`
