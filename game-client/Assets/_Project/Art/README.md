# Quy chuẩn Đồ họa (Art Guidelines)

Thư mục này chứa toàn bộ tài nguyên đồ họa 2D, sprites, animations, tilesets, materials và UI textures cho **Bloodfiend**.

---

## 1. Cấu trúc Thư mục

```text
Art/
├── Animations/          # Animation Clips (.anim) và Animator Controllers (.controller)
├── Environments/        # Đồ họa màn chơi & kiến trúc biệt thự
│   ├── Props/           # Đồ đạc tĩnh & động (bàn ghế, vết máu, chấn song sắt, cửa)
│   └── Tilesets/        # Rule Tiles, gạch lát sàn, tường gỗ/đá
├── Materials/           # Material dùng shader 2D Lit, normal maps cho bề mặt
├── Sprites/             # Sprite sheet gốc và đã cắt lát
│   ├── Characters/      # Sprite nhân vật chính (An), đồng đội (Phúc)
│   ├── Enemies/         # Sprite sheet các loài quái (Speedster, Regenerator, Bosses)
│   └── Items/           # Icon trang bị, vũ khí, đạn dược, pin đèn pin, mảnh ghi chép
└── UI/                  # Khung viền HUD, thanh máu, ô lưới kho đồ, font chữ
```

---

## 2. Tiêu chuẩn Cấu hình Import Sprite

Để đảm bảo hình ảnh hiển thị sắc nét, không bị nhòe hoặc méo mó:

* **Texture Type:** `Sprite (2D and UI)`
* **Sprite Mode:** `Single` cho vật phẩm/icon đứng một mình; `Multiple` cho bảng sprite sheet nhân vật/animation.
* **Pixels Per Unit (PPU):** Thiết lập đồng nhất cho toàn dự án (thường là `16` hoặc `32` PPU tùy theo phong cách vẽ).
* **Filter Mode:**
  * Nếu vẽ Pixel Art: Chọn `Point (no filter)`.
  * Nếu vẽ High-Res 2D: Chọn `Bilinear`.
* **Compression:** Chọn `None` hoặc `High Quality` (tránh để nén làm vỡ hạt ở các vùng viền tối).
* **Điểm neo (Pivot Points):**
  * Nhân vật & Quái vật: Chọn `Bottom` hoặc vị trí chân tiếp đất để thuật toán sắp xếp chiều sâu (Y-sorting / Depth sorting) hoạt động chính xác.
  * Vật phẩm & UI: Chọn `Center`.

---

## 3. Hệ thống Chiếu sáng 2D & Normal Maps (URP 2D)

Vì Bloodfiend là game kinh dị phụ thuộc nặng vào ánh sáng đèn pin và bóng tối:
1. **Material Lit 2D:** Mọi Sprite tường, sàn và nhân vật phải dùng Material có shader `Universal Render Pipeline/2D/Sprite-Lit-Default`.
2. **Normal Maps:** Khi vẽ tường gạch hoặc cơ thể quái vật, hãy tạo thêm map độ lồi lõm (Normal Map) để khi ánh đèn pin rọi vào, bề mặt sẽ hiển thị gồ ghề chân thực.
3. **Bóng đổ (Shadow Caster 2D):** Toàn bộ tường, cột nhà và tủ lớn phải được gắn component `Shadow Caster 2D` để cản tia sáng đèn pin và tạo ra các góc khuất đen tối cho quái vật ẩn nấp.

---

## 4. Các Định dạng File Hỗ trợ

* **PNG:** Định dạng chuẩn để xuất sprite sheet hoàn thiện.
* **Aseprite (`.ase`, `.aseprite`):** Hỗ trợ trực tiếp qua package `com.unity.2d.aseprite`. Có thể lưu thẳng file gốc vào `Sprites/`.
* **Photoshop (`.psd`, `.psb`):** Hỗ trợ trực tiếp qua `com.unity.2d.psdimporter`.
