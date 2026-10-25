# Quy chuẩn Âm thanh (Audio Guidelines)

Thư mục này quản lý toàn bộ tài nguyên âm thanh, nhạc nền, tiếng động môi trường và hiệu ứng SFX cho **Bloodfiend**.

---

## 1. Cấu trúc Thư mục

```text
Audio/
├── Music/               # Nhạc nền, ambient không khí ngột ngạt, nhạc đấu Boss
└── SFX/                 # Hiệu ứng âm thanh (hành động người chơi, tiếng quái, tương tác)
```

---

## 2. Tiêu chuẩn Định dạng & Nén File Âm thanh

| Loại âm thanh | Định dạng khuyên dùng | Load Type trong Unity | Kiểu nén (Compression) | Chất lượng |
| :--- | :--- | :--- | :--- | :--- |
| **SFX ngắn** (tiếng bước chân, tiếng click, tiếng lên đạn) | `.wav` (Không nén) | *Decompress On Load* | `PCM` hoặc `ADPCM` | 100% |
| **SFX trung bình** (tiếng gầm của quái, tiếng thở, tiếng súng) | `.wav` / `.ogg` | *Compressed In Memory* | `Vorbis` | 70% - 80% |
| **Nhạc nền & Ambient dài** | `.ogg` / `.mp3` | *Streaming* | `Vorbis` | 70% |

---

## 3. Kiến trúc Tuyến Kênh trong AudioMixer

Mọi nguồn phát âm thanh (`AudioSource`) trong game **bắt buộc phải nối ra một tuyến kênh (Bus) trong AudioMixer**, không phát thẳng ra loa:

* **Master**
  * ├── **Music:** Nhạc nền, bản nhạc dồn dập khi bị rượt đuổi.
  * └── **SFX**
      * ├── **Player:** Tiếng bước chân (đi bộ nhẹ nhàng vs chạy thình thịch), tiếng thở dốc, nhịp tim.
      * ├── **Monsters:** Tiếng gầm gừ, tiếng thét của Screecher, tiếng bò của Lurker.
      * ├── **Environment:** Tiếng mưa đập cửa sổ, tiếng đèn lập lòe, tiếng cót két của cửa gỗ.
      * └── **UI:** Tiếng mở kho đồ, tiếng lật trang giấy nhật ký, tiếng xoay ổ khóa.

---

## 4. Tiêu chuẩn Âm thanh Game Kinh dị

1. **Vòng lặp Ambient (Seamless Loop):** Các đoạn âm thanh môi trường u ám phải được cắt ghép vòng lặp liền mạch, tuyệt đối không bị giật hoặc phát ra tiếng "click" khi lặp lại.
2. **Âm thanh Không gian 2D (Spatialization):** Các âm thanh quái vật di chuyển trong góc khuất phải được bật mô phỏng âm thanh nổi 2D để người chơi đeo tai nghe có thể đoán được hướng quái vật đang tiến lại gần.
3. **Hiệu ứng Ù tai (Tinnitus):** Khi bị Screecher thét hoặc trúng lựu đạn chớp sáng, kích hoạt Snapshot trong AudioMixer để dìm toàn bộ âm thanh môi trường xuống và chỉ phát tiếng vo ve chói tai.
