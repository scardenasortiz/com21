﻿function validateCreditCard(s) {
    var v = "0123456789"; var w = ""; for (i = 0; i < s.length; i++) {
        x = s.charAt(i); if (v.indexOf(x, 0) != -1)
            w += x;
    }
    j = w.length / 2; k = Math.floor(j); m = Math.ceil(j) - k; c = 0; for (i = 0; i < k; i++) { a = w.charAt(i * 2 + m) * 2; c += a > 9 ? Math.floor(a / 10 + a % 10) : a; }
    for (i = 0; i < k + m; i++) c += w.charAt(i * 2 + 1 - m) * 1; return (c % 10 == 0);
}