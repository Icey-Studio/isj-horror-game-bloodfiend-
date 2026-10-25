# Quy chuẩn Quản lý Prefabs

Thư mục này chứa toàn bộ các GameObject đã được lắp ráp hoàn chỉnh thành **Prefab** có thể tái sử dụng cho **Bloodfiend**.

---

## 1. Cấu trúc Thư mục

```text
Prefabs/
├── Characters/          # Người chơi (An) và NPC đồng hành (Phúc)
├── Enemies/             # Quái vật (Speedster, Regenerator, Lurker, Screecher, Bosses)
├── Interactables/       # Vật thể tương tác (Cửa, Rèm cửa sổ, Chìa khóa, Công tắc đèn)
├── Puzzles/             # Cơ chế câu đố (Két khóa số, Bảng phân phối điện cầu chì)
└── UI/                  # Canvas HUD, Popup đọc tài liệu, Bảng giao diện kho đồ
```

---

## 2. Quy tắc Bắt buộc khi Làm việc với Prefab

1. **Chỉnh sửa bằng Prefab Mode:**
   * Luôn đúp chuột vào file Prefab trong thẻ Project để mở **Prefab Mode** riêng biệt khi cần chỉnh sửa.
   * Không sửa trực tiếp một con quái/cánh cửa trên Scene rồi bấm "Apply All" vì rất dễ làm sai lệch vị trí của các đối tượng khác trên màn chơi.
2. **Tuyệt đối không Unpack Prefab:**
   * Không bấm chuột phải chọn "Unpack Prefab" trên Scene. Nếu bạn unpack, đối tượng đó sẽ bị đứt liên kết với file gốc và không còn nhận được các cập nhật code mới nữa.
3. **Sử dụng Prefab Variants cho Quái vật biến thể:**
   * Tạo một `BaseEnemy` làm Prefab cha (chứa sẵn thanh máu, collider, script nhận sát thương).
   * Tạo các **Prefab Variant** từ cha:
     * `Speedster_Variant`: Thay đổi tốc độ di chuyển cao hơn, thêm bộ lắng nghe âm thanh.
     * `Regenerator_Variant`: Thêm component tự hồi máu và điểm yếu ánh sáng mạnh.
4. **Tính độc lập của Prefab (Self-Contained):**
   * Một Prefab khi kéo vào bất kỳ Scene trống nào cũng phải hoạt động được ngay lập tức, không được phụ thuộc cứng vào một GameObject khác đang nằm sẵn trên Scene.
