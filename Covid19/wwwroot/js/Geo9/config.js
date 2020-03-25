var GlobalConfig = {
    pwstrength: {
        errorMessages: {
            wordLength: "รหัสผ่านสั้นเกินไป",
            wordSimilarToUsername: "ห้ามใช้รหัสผ่านคล้ายชื่อเข้าใช้งาน"
        },
        verdicts: ["อ่อนแอ", "ปกติ", "ปานกลาง", "ปลอดภัย", "ปลอดภัยมาก"],
        rules: {
            scores: {
                wordSequences: -100
            },
            activated: {
                wordNotEmail: false,
                wordSimilarToUsername: false,
                wordSequences:false
            }
        }
    }
};