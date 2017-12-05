using System.Collections.Generic;

public class Question
{

    public int QuestionNumber;
    public string Text;
    public string[] Choices;
    public int CorrectChoiceIndex;

public static List<Question> QuestionList1 = new List<Question>
{
    new Question(1, "ขอบฟุตบาทสี ขาวสลับแดง ดังภาพ ข้อใดถูกต้องที่สุด", 0, "ห้ามหยุดห้ามจอด", "หยุดจอดรับส่งผู้โดยสารได้ชั่วขณะ", "จอดได้ถ้าสนิทกับจราจร", "ห้ามจอดแช่"),
    new Question(2, "ภาพป้ายจราจรนี้ หมายความว่า", 0, "ห้ามหยุดรถ", "ห้ามเข้า", "ห้ามผ่าน", "ห้ามจอดรถ")
};

public static List<Question> QuestionList2 = new List<Question>
{
    new Question(29, "ผลการศึกษาวิจัยเปรียบเทียบการขับรถเร็วแล้วชนกับการตกจากที่สูง ถ้าขับเร็ว 120 กม./ชม. เทียบได้กับการตกตึกกี่ชั้น", 2, "4 ชั้น", "12 ชั้น", "19 ชั้น", "25 ชั้น"),
    new Question(30, "สถานการณ์ใดใช้ไฟฉุกเฉินได้อย่างเหมาะสม", 3, "เปิดไฟฉุกเฉินในขณะที่หมอกลงจัด", "เปิดไฟฉุกเฉินเมื่อกำลังจะเลี้ยวซ้ายบริเวณทางแยกที่ไม่มีสัญญาณไฟจราจร", "เปิดไฟฉุกเฉินเพื่อให้ผู้ขับขี่ท่านอื่นทราบว่าตนจะวิ่งตรงไป", "เปิดไฟฉุกเฉินเมื่อรถจอดเสียอยู่บริเวณไหล่ทาง")
};

    public Question(int questionNumber, string text, int correctChoiceIndex, params string[] choices)
    {
        QuestionNumber = questionNumber;
        Text = text;
        CorrectChoiceIndex = correctChoiceIndex;
        Choices = choices;
    }
}