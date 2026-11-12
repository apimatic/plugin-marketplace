using System;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Enum;

namespace UpvestInvestmentApi.Models.Enums;

/// <summary>
/// Accepted country code. <see href="https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2">ISO 3166-1 alpha-2 codes</see>.
/// </summary>
[JsonConverter(typeof(StringEnumConverter<IssuingCountry>))]
public sealed record IssuingCountry : OpenStringEnum<IssuingCountry>
{
    private IssuingCountry(string value) : base(value)
    {
    }

    public static readonly IssuingCountry Ad = new("AD");

    public static readonly IssuingCountry Ae = new("AE");

    public static readonly IssuingCountry Af = new("AF");

    public static readonly IssuingCountry Ag = new("AG");

    public static readonly IssuingCountry Ai = new("AI");

    public static readonly IssuingCountry Al = new("AL");

    public static readonly IssuingCountry Am = new("AM");

    public static readonly IssuingCountry Ao = new("AO");

    public static readonly IssuingCountry Aq = new("AQ");

    public static readonly IssuingCountry Ar = new("AR");

    public static readonly IssuingCountry As = new("AS");

    public static readonly IssuingCountry At = new("AT");

    public static readonly IssuingCountry Au = new("AU");

    public static readonly IssuingCountry Aw = new("AW");

    public static readonly IssuingCountry Ax = new("AX");

    public static readonly IssuingCountry Az = new("AZ");

    public static readonly IssuingCountry Ba = new("BA");

    public static readonly IssuingCountry Bb = new("BB");

    public static readonly IssuingCountry Bd = new("BD");

    public static readonly IssuingCountry Be = new("BE");

    public static readonly IssuingCountry Bf = new("BF");

    public static readonly IssuingCountry Bg = new("BG");

    public static readonly IssuingCountry Bh = new("BH");

    public static readonly IssuingCountry Bi = new("BI");

    public static readonly IssuingCountry Bj = new("BJ");

    public static readonly IssuingCountry Bl = new("BL");

    public static readonly IssuingCountry Bm = new("BM");

    public static readonly IssuingCountry Bn = new("BN");

    public static readonly IssuingCountry Bo = new("BO");

    public static readonly IssuingCountry Bq = new("BQ");

    public static readonly IssuingCountry Br = new("BR");

    public static readonly IssuingCountry Bs = new("BS");

    public static readonly IssuingCountry Bt = new("BT");

    public static readonly IssuingCountry Bv = new("BV");

    public static readonly IssuingCountry Bw = new("BW");

    public static readonly IssuingCountry By = new("BY");

    public static readonly IssuingCountry Bz = new("BZ");

    public static readonly IssuingCountry Ca = new("CA");

    public static readonly IssuingCountry Cc = new("CC");

    public static readonly IssuingCountry Cd = new("CD");

    public static readonly IssuingCountry Cf = new("CF");

    public static readonly IssuingCountry Cg = new("CG");

    public static readonly IssuingCountry Ch = new("CH");

    public static readonly IssuingCountry Ci = new("CI");

    public static readonly IssuingCountry Ck = new("CK");

    public static readonly IssuingCountry Cl = new("CL");

    public static readonly IssuingCountry Cm = new("CM");

    public static readonly IssuingCountry Cn = new("CN");

    public static readonly IssuingCountry Co = new("CO");

    public static readonly IssuingCountry Cr = new("CR");

    public static readonly IssuingCountry Cu = new("CU");

    public static readonly IssuingCountry Cv = new("CV");

    public static readonly IssuingCountry Cw = new("CW");

    public static readonly IssuingCountry Cx = new("CX");

    public static readonly IssuingCountry Cy = new("CY");

    public static readonly IssuingCountry Cz = new("CZ");

    public static readonly IssuingCountry De = new("DE");

    public static readonly IssuingCountry Dj = new("DJ");

    public static readonly IssuingCountry Dk = new("DK");

    public static readonly IssuingCountry Dm = new("DM");

    public static readonly IssuingCountry Do = new("DO");

    public static readonly IssuingCountry Dz = new("DZ");

    public static readonly IssuingCountry Ec = new("EC");

    public static readonly IssuingCountry Ee = new("EE");

    public static readonly IssuingCountry Eg = new("EG");

    public static readonly IssuingCountry Eh = new("EH");

    public static readonly IssuingCountry Er = new("ER");

    public static readonly IssuingCountry Es = new("ES");

    public static readonly IssuingCountry Et = new("ET");

    public static readonly IssuingCountry Fi = new("FI");

    public static readonly IssuingCountry Fj = new("FJ");

    public static readonly IssuingCountry Fk = new("FK");

    public static readonly IssuingCountry Fm = new("FM");

    public static readonly IssuingCountry Fo = new("FO");

    public static readonly IssuingCountry Fr = new("FR");

    public static readonly IssuingCountry Ga = new("GA");

    public static readonly IssuingCountry Gb = new("GB");

    public static readonly IssuingCountry Gd = new("GD");

    public static readonly IssuingCountry Ge = new("GE");

    public static readonly IssuingCountry Gf = new("GF");

    public static readonly IssuingCountry Gg = new("GG");

    public static readonly IssuingCountry Gh = new("GH");

    public static readonly IssuingCountry Gi = new("GI");

    public static readonly IssuingCountry Gl = new("GL");

    public static readonly IssuingCountry Gm = new("GM");

    public static readonly IssuingCountry Gn = new("GN");

    public static readonly IssuingCountry Gp = new("GP");

    public static readonly IssuingCountry Gq = new("GQ");

    public static readonly IssuingCountry Gr = new("GR");

    public static readonly IssuingCountry Gs = new("GS");

    public static readonly IssuingCountry Gt = new("GT");

    public static readonly IssuingCountry Gu = new("GU");

    public static readonly IssuingCountry Gw = new("GW");

    public static readonly IssuingCountry Gy = new("GY");

    public static readonly IssuingCountry Hk = new("HK");

    public static readonly IssuingCountry Hm = new("HM");

    public static readonly IssuingCountry Hn = new("HN");

    public static readonly IssuingCountry Hr = new("HR");

    public static readonly IssuingCountry Ht = new("HT");

    public static readonly IssuingCountry Hu = new("HU");

    public static readonly IssuingCountry Id = new("ID");

    public static readonly IssuingCountry Ie = new("IE");

    public static readonly IssuingCountry Il = new("IL");

    public static readonly IssuingCountry Im = new("IM");

    public static readonly IssuingCountry In = new("IN");

    public static readonly IssuingCountry Io = new("IO");

    public static readonly IssuingCountry Iq = new("IQ");

    public static readonly IssuingCountry Ir = new("IR");

    public static readonly IssuingCountry IsMember = new("IS");

    public static readonly IssuingCountry It = new("IT");

    public static readonly IssuingCountry Je = new("JE");

    public static readonly IssuingCountry Jm = new("JM");

    public static readonly IssuingCountry Jo = new("JO");

    public static readonly IssuingCountry Jp = new("JP");

    public static readonly IssuingCountry Ke = new("KE");

    public static readonly IssuingCountry Kg = new("KG");

    public static readonly IssuingCountry Kh = new("KH");

    public static readonly IssuingCountry Ki = new("KI");

    public static readonly IssuingCountry Km = new("KM");

    public static readonly IssuingCountry Kn = new("KN");

    public static readonly IssuingCountry Kp = new("KP");

    public static readonly IssuingCountry Kr = new("KR");

    public static readonly IssuingCountry Kw = new("KW");

    public static readonly IssuingCountry Ky = new("KY");

    public static readonly IssuingCountry Kz = new("KZ");

    public static readonly IssuingCountry La = new("LA");

    public static readonly IssuingCountry Lb = new("LB");

    public static readonly IssuingCountry Lc = new("LC");

    public static readonly IssuingCountry Li = new("LI");

    public static readonly IssuingCountry Lk = new("LK");

    public static readonly IssuingCountry Lr = new("LR");

    public static readonly IssuingCountry Ls = new("LS");

    public static readonly IssuingCountry Lt = new("LT");

    public static readonly IssuingCountry Lu = new("LU");

    public static readonly IssuingCountry Lv = new("LV");

    public static readonly IssuingCountry Ly = new("LY");

    public static readonly IssuingCountry Ma = new("MA");

    public static readonly IssuingCountry Mc = new("MC");

    public static readonly IssuingCountry Md = new("MD");

    public static readonly IssuingCountry Me = new("ME");

    public static readonly IssuingCountry Mf = new("MF");

    public static readonly IssuingCountry Mg = new("MG");

    public static readonly IssuingCountry Mh = new("MH");

    public static readonly IssuingCountry Mk = new("MK");

    public static readonly IssuingCountry Ml = new("ML");

    public static readonly IssuingCountry Mm = new("MM");

    public static readonly IssuingCountry Mn = new("MN");

    public static readonly IssuingCountry Mo = new("MO");

    public static readonly IssuingCountry Mp = new("MP");

    public static readonly IssuingCountry Mq = new("MQ");

    public static readonly IssuingCountry Mr = new("MR");

    public static readonly IssuingCountry Ms = new("MS");

    public static readonly IssuingCountry Mt = new("MT");

    public static readonly IssuingCountry Mu = new("MU");

    public static readonly IssuingCountry Mv = new("MV");

    public static readonly IssuingCountry Mw = new("MW");

    public static readonly IssuingCountry Mx = new("MX");

    public static readonly IssuingCountry My = new("MY");

    public static readonly IssuingCountry Mz = new("MZ");

    public static readonly IssuingCountry Na = new("NA");

    public static readonly IssuingCountry Nc = new("NC");

    public static readonly IssuingCountry Ne = new("NE");

    public static readonly IssuingCountry Nf = new("NF");

    public static readonly IssuingCountry Ng = new("NG");

    public static readonly IssuingCountry Ni = new("NI");

    public static readonly IssuingCountry Nl = new("NL");

    public static readonly IssuingCountry No = new("NO");

    public static readonly IssuingCountry Np = new("NP");

    public static readonly IssuingCountry Nr = new("NR");

    public static readonly IssuingCountry Nu = new("NU");

    public static readonly IssuingCountry Nz = new("NZ");

    public static readonly IssuingCountry Om = new("OM");

    public static readonly IssuingCountry Pa = new("PA");

    public static readonly IssuingCountry Pe = new("PE");

    public static readonly IssuingCountry Pf = new("PF");

    public static readonly IssuingCountry Pg = new("PG");

    public static readonly IssuingCountry Ph = new("PH");

    public static readonly IssuingCountry Pk = new("PK");

    public static readonly IssuingCountry Pl = new("PL");

    public static readonly IssuingCountry Pm = new("PM");

    public static readonly IssuingCountry Pn = new("PN");

    public static readonly IssuingCountry Pr = new("PR");

    public static readonly IssuingCountry Ps = new("PS");

    public static readonly IssuingCountry Pt = new("PT");

    public static readonly IssuingCountry Pw = new("PW");

    public static readonly IssuingCountry Py = new("PY");

    public static readonly IssuingCountry Qa = new("QA");

    public static readonly IssuingCountry Re = new("RE");

    public static readonly IssuingCountry Ro = new("RO");

    public static readonly IssuingCountry Rs = new("RS");

    public static readonly IssuingCountry Ru = new("RU");

    public static readonly IssuingCountry Rw = new("RW");

    public static readonly IssuingCountry Sa = new("SA");

    public static readonly IssuingCountry Sb = new("SB");

    public static readonly IssuingCountry Sc = new("SC");

    public static readonly IssuingCountry Sd = new("SD");

    public static readonly IssuingCountry Se = new("SE");

    public static readonly IssuingCountry Sg = new("SG");

    public static readonly IssuingCountry Sh = new("SH");

    public static readonly IssuingCountry Si = new("SI");

    public static readonly IssuingCountry Sj = new("SJ");

    public static readonly IssuingCountry Sk = new("SK");

    public static readonly IssuingCountry Sl = new("SL");

    public static readonly IssuingCountry Sm = new("SM");

    public static readonly IssuingCountry Sn = new("SN");

    public static readonly IssuingCountry So = new("SO");

    public static readonly IssuingCountry Sr = new("SR");

    public static readonly IssuingCountry Ss = new("SS");

    public static readonly IssuingCountry St = new("ST");

    public static readonly IssuingCountry Sv = new("SV");

    public static readonly IssuingCountry Sx = new("SX");

    public static readonly IssuingCountry Sy = new("SY");

    public static readonly IssuingCountry Sz = new("SZ");

    public static readonly IssuingCountry Tc = new("TC");

    public static readonly IssuingCountry Td = new("TD");

    public static readonly IssuingCountry Tf = new("TF");

    public static readonly IssuingCountry Tg = new("TG");

    public static readonly IssuingCountry Th = new("TH");

    public static readonly IssuingCountry Tj = new("TJ");

    public static readonly IssuingCountry Tk = new("TK");

    public static readonly IssuingCountry Tl = new("TL");

    public static readonly IssuingCountry Tm = new("TM");

    public static readonly IssuingCountry Tn = new("TN");

    public static readonly IssuingCountry To = new("TO");

    public static readonly IssuingCountry Tr = new("TR");

    public static readonly IssuingCountry Tt = new("TT");

    public static readonly IssuingCountry Tv = new("TV");

    public static readonly IssuingCountry Tw = new("TW");

    public static readonly IssuingCountry Tz = new("TZ");

    public static readonly IssuingCountry Ua = new("UA");

    public static readonly IssuingCountry Ug = new("UG");

    public static readonly IssuingCountry Um = new("UM");

    public static readonly IssuingCountry Us = new("US");

    public static readonly IssuingCountry Uy = new("UY");

    public static readonly IssuingCountry Uz = new("UZ");

    public static readonly IssuingCountry Va = new("VA");

    public static readonly IssuingCountry Vc = new("VC");

    public static readonly IssuingCountry Ve = new("VE");

    public static readonly IssuingCountry Vg = new("VG");

    public static readonly IssuingCountry Vi = new("VI");

    public static readonly IssuingCountry Vn = new("VN");

    public static readonly IssuingCountry Vu = new("VU");

    public static readonly IssuingCountry Wf = new("WF");

    public static readonly IssuingCountry Ws = new("WS");

    public static readonly IssuingCountry Xk = new("XK");

    public static readonly IssuingCountry Ye = new("YE");

    public static readonly IssuingCountry Yt = new("YT");

    public static readonly IssuingCountry Za = new("ZA");

    public static readonly IssuingCountry Zm = new("ZM");

    public static readonly IssuingCountry Zw = new("ZW");

    public TResult Match<TResult>(Func<TResult> onAd,
        Func<TResult> onAe,
        Func<TResult> onAf,
        Func<TResult> onAg,
        Func<TResult> onAi,
        Func<TResult> onAl,
        Func<TResult> onAm,
        Func<TResult> onAo,
        Func<TResult> onAq,
        Func<TResult> onAr,
        Func<TResult> onAs,
        Func<TResult> onAt,
        Func<TResult> onAu,
        Func<TResult> onAw,
        Func<TResult> onAx,
        Func<TResult> onAz,
        Func<TResult> onBa,
        Func<TResult> onBb,
        Func<TResult> onBd,
        Func<TResult> onBe,
        Func<TResult> onBf,
        Func<TResult> onBg,
        Func<TResult> onBh,
        Func<TResult> onBi,
        Func<TResult> onBj,
        Func<TResult> onBl,
        Func<TResult> onBm,
        Func<TResult> onBn,
        Func<TResult> onBo,
        Func<TResult> onBq,
        Func<TResult> onBr,
        Func<TResult> onBs,
        Func<TResult> onBt,
        Func<TResult> onBv,
        Func<TResult> onBw,
        Func<TResult> onBy,
        Func<TResult> onBz,
        Func<TResult> onCa,
        Func<TResult> onCc,
        Func<TResult> onCd,
        Func<TResult> onCf,
        Func<TResult> onCg,
        Func<TResult> onCh,
        Func<TResult> onCi,
        Func<TResult> onCk,
        Func<TResult> onCl,
        Func<TResult> onCm,
        Func<TResult> onCn,
        Func<TResult> onCo,
        Func<TResult> onCr,
        Func<TResult> onCu,
        Func<TResult> onCv,
        Func<TResult> onCw,
        Func<TResult> onCx,
        Func<TResult> onCy,
        Func<TResult> onCz,
        Func<TResult> onDe,
        Func<TResult> onDj,
        Func<TResult> onDk,
        Func<TResult> onDm,
        Func<TResult> onDo,
        Func<TResult> onDz,
        Func<TResult> onEc,
        Func<TResult> onEe,
        Func<TResult> onEg,
        Func<TResult> onEh,
        Func<TResult> onEr,
        Func<TResult> onEs,
        Func<TResult> onEt,
        Func<TResult> onFi,
        Func<TResult> onFj,
        Func<TResult> onFk,
        Func<TResult> onFm,
        Func<TResult> onFo,
        Func<TResult> onFr,
        Func<TResult> onGa,
        Func<TResult> onGb,
        Func<TResult> onGd,
        Func<TResult> onGe,
        Func<TResult> onGf,
        Func<TResult> onGg,
        Func<TResult> onGh,
        Func<TResult> onGi,
        Func<TResult> onGl,
        Func<TResult> onGm,
        Func<TResult> onGn,
        Func<TResult> onGp,
        Func<TResult> onGq,
        Func<TResult> onGr,
        Func<TResult> onGs,
        Func<TResult> onGt,
        Func<TResult> onGu,
        Func<TResult> onGw,
        Func<TResult> onGy,
        Func<TResult> onHk,
        Func<TResult> onHm,
        Func<TResult> onHn,
        Func<TResult> onHr,
        Func<TResult> onHt,
        Func<TResult> onHu,
        Func<TResult> onId,
        Func<TResult> onIe,
        Func<TResult> onIl,
        Func<TResult> onIm,
        Func<TResult> onIn,
        Func<TResult> onIo,
        Func<TResult> onIq,
        Func<TResult> onIr,
        Func<TResult> onIsMember,
        Func<TResult> onIt,
        Func<TResult> onJe,
        Func<TResult> onJm,
        Func<TResult> onJo,
        Func<TResult> onJp,
        Func<TResult> onKe,
        Func<TResult> onKg,
        Func<TResult> onKh,
        Func<TResult> onKi,
        Func<TResult> onKm,
        Func<TResult> onKn,
        Func<TResult> onKp,
        Func<TResult> onKr,
        Func<TResult> onKw,
        Func<TResult> onKy,
        Func<TResult> onKz,
        Func<TResult> onLa,
        Func<TResult> onLb,
        Func<TResult> onLc,
        Func<TResult> onLi,
        Func<TResult> onLk,
        Func<TResult> onLr,
        Func<TResult> onLs,
        Func<TResult> onLt,
        Func<TResult> onLu,
        Func<TResult> onLv,
        Func<TResult> onLy,
        Func<TResult> onMa,
        Func<TResult> onMc,
        Func<TResult> onMd,
        Func<TResult> onMe,
        Func<TResult> onMf,
        Func<TResult> onMg,
        Func<TResult> onMh,
        Func<TResult> onMk,
        Func<TResult> onMl,
        Func<TResult> onMm,
        Func<TResult> onMn,
        Func<TResult> onMo,
        Func<TResult> onMp,
        Func<TResult> onMq,
        Func<TResult> onMr,
        Func<TResult> onMs,
        Func<TResult> onMt,
        Func<TResult> onMu,
        Func<TResult> onMv,
        Func<TResult> onMw,
        Func<TResult> onMx,
        Func<TResult> onMy,
        Func<TResult> onMz,
        Func<TResult> onNa,
        Func<TResult> onNc,
        Func<TResult> onNe,
        Func<TResult> onNf,
        Func<TResult> onNg,
        Func<TResult> onNi,
        Func<TResult> onNl,
        Func<TResult> onNo,
        Func<TResult> onNp,
        Func<TResult> onNr,
        Func<TResult> onNu,
        Func<TResult> onNz,
        Func<TResult> onOm,
        Func<TResult> onPa,
        Func<TResult> onPe,
        Func<TResult> onPf,
        Func<TResult> onPg,
        Func<TResult> onPh,
        Func<TResult> onPk,
        Func<TResult> onPl,
        Func<TResult> onPm,
        Func<TResult> onPn,
        Func<TResult> onPr,
        Func<TResult> onPs,
        Func<TResult> onPt,
        Func<TResult> onPw,
        Func<TResult> onPy,
        Func<TResult> onQa,
        Func<TResult> onRe,
        Func<TResult> onRo,
        Func<TResult> onRs,
        Func<TResult> onRu,
        Func<TResult> onRw,
        Func<TResult> onSa,
        Func<TResult> onSb,
        Func<TResult> onSc,
        Func<TResult> onSd,
        Func<TResult> onSe,
        Func<TResult> onSg,
        Func<TResult> onSh,
        Func<TResult> onSi,
        Func<TResult> onSj,
        Func<TResult> onSk,
        Func<TResult> onSl,
        Func<TResult> onSm,
        Func<TResult> onSn,
        Func<TResult> onSo,
        Func<TResult> onSr,
        Func<TResult> onSs,
        Func<TResult> onSt,
        Func<TResult> onSv,
        Func<TResult> onSx,
        Func<TResult> onSy,
        Func<TResult> onSz,
        Func<TResult> onTc,
        Func<TResult> onTd,
        Func<TResult> onTf,
        Func<TResult> onTg,
        Func<TResult> onTh,
        Func<TResult> onTj,
        Func<TResult> onTk,
        Func<TResult> onTl,
        Func<TResult> onTm,
        Func<TResult> onTn,
        Func<TResult> onTo,
        Func<TResult> onTr,
        Func<TResult> onTt,
        Func<TResult> onTv,
        Func<TResult> onTw,
        Func<TResult> onTz,
        Func<TResult> onUa,
        Func<TResult> onUg,
        Func<TResult> onUm,
        Func<TResult> onUs,
        Func<TResult> onUy,
        Func<TResult> onUz,
        Func<TResult> onVa,
        Func<TResult> onVc,
        Func<TResult> onVe,
        Func<TResult> onVg,
        Func<TResult> onVi,
        Func<TResult> onVn,
        Func<TResult> onVu,
        Func<TResult> onWf,
        Func<TResult> onWs,
        Func<TResult> onXk,
        Func<TResult> onYe,
        Func<TResult> onYt,
        Func<TResult> onZa,
        Func<TResult> onZm,
        Func<TResult> onZw,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == Ad => onAd(),
            _ when this == Ae => onAe(),
            _ when this == Af => onAf(),
            _ when this == Ag => onAg(),
            _ when this == Ai => onAi(),
            _ when this == Al => onAl(),
            _ when this == Am => onAm(),
            _ when this == Ao => onAo(),
            _ when this == Aq => onAq(),
            _ when this == Ar => onAr(),
            _ when this == As => onAs(),
            _ when this == At => onAt(),
            _ when this == Au => onAu(),
            _ when this == Aw => onAw(),
            _ when this == Ax => onAx(),
            _ when this == Az => onAz(),
            _ when this == Ba => onBa(),
            _ when this == Bb => onBb(),
            _ when this == Bd => onBd(),
            _ when this == Be => onBe(),
            _ when this == Bf => onBf(),
            _ when this == Bg => onBg(),
            _ when this == Bh => onBh(),
            _ when this == Bi => onBi(),
            _ when this == Bj => onBj(),
            _ when this == Bl => onBl(),
            _ when this == Bm => onBm(),
            _ when this == Bn => onBn(),
            _ when this == Bo => onBo(),
            _ when this == Bq => onBq(),
            _ when this == Br => onBr(),
            _ when this == Bs => onBs(),
            _ when this == Bt => onBt(),
            _ when this == Bv => onBv(),
            _ when this == Bw => onBw(),
            _ when this == By => onBy(),
            _ when this == Bz => onBz(),
            _ when this == Ca => onCa(),
            _ when this == Cc => onCc(),
            _ when this == Cd => onCd(),
            _ when this == Cf => onCf(),
            _ when this == Cg => onCg(),
            _ when this == Ch => onCh(),
            _ when this == Ci => onCi(),
            _ when this == Ck => onCk(),
            _ when this == Cl => onCl(),
            _ when this == Cm => onCm(),
            _ when this == Cn => onCn(),
            _ when this == Co => onCo(),
            _ when this == Cr => onCr(),
            _ when this == Cu => onCu(),
            _ when this == Cv => onCv(),
            _ when this == Cw => onCw(),
            _ when this == Cx => onCx(),
            _ when this == Cy => onCy(),
            _ when this == Cz => onCz(),
            _ when this == De => onDe(),
            _ when this == Dj => onDj(),
            _ when this == Dk => onDk(),
            _ when this == Dm => onDm(),
            _ when this == Do => onDo(),
            _ when this == Dz => onDz(),
            _ when this == Ec => onEc(),
            _ when this == Ee => onEe(),
            _ when this == Eg => onEg(),
            _ when this == Eh => onEh(),
            _ when this == Er => onEr(),
            _ when this == Es => onEs(),
            _ when this == Et => onEt(),
            _ when this == Fi => onFi(),
            _ when this == Fj => onFj(),
            _ when this == Fk => onFk(),
            _ when this == Fm => onFm(),
            _ when this == Fo => onFo(),
            _ when this == Fr => onFr(),
            _ when this == Ga => onGa(),
            _ when this == Gb => onGb(),
            _ when this == Gd => onGd(),
            _ when this == Ge => onGe(),
            _ when this == Gf => onGf(),
            _ when this == Gg => onGg(),
            _ when this == Gh => onGh(),
            _ when this == Gi => onGi(),
            _ when this == Gl => onGl(),
            _ when this == Gm => onGm(),
            _ when this == Gn => onGn(),
            _ when this == Gp => onGp(),
            _ when this == Gq => onGq(),
            _ when this == Gr => onGr(),
            _ when this == Gs => onGs(),
            _ when this == Gt => onGt(),
            _ when this == Gu => onGu(),
            _ when this == Gw => onGw(),
            _ when this == Gy => onGy(),
            _ when this == Hk => onHk(),
            _ when this == Hm => onHm(),
            _ when this == Hn => onHn(),
            _ when this == Hr => onHr(),
            _ when this == Ht => onHt(),
            _ when this == Hu => onHu(),
            _ when this == Id => onId(),
            _ when this == Ie => onIe(),
            _ when this == Il => onIl(),
            _ when this == Im => onIm(),
            _ when this == In => onIn(),
            _ when this == Io => onIo(),
            _ when this == Iq => onIq(),
            _ when this == Ir => onIr(),
            _ when this == IsMember => onIsMember(),
            _ when this == It => onIt(),
            _ when this == Je => onJe(),
            _ when this == Jm => onJm(),
            _ when this == Jo => onJo(),
            _ when this == Jp => onJp(),
            _ when this == Ke => onKe(),
            _ when this == Kg => onKg(),
            _ when this == Kh => onKh(),
            _ when this == Ki => onKi(),
            _ when this == Km => onKm(),
            _ when this == Kn => onKn(),
            _ when this == Kp => onKp(),
            _ when this == Kr => onKr(),
            _ when this == Kw => onKw(),
            _ when this == Ky => onKy(),
            _ when this == Kz => onKz(),
            _ when this == La => onLa(),
            _ when this == Lb => onLb(),
            _ when this == Lc => onLc(),
            _ when this == Li => onLi(),
            _ when this == Lk => onLk(),
            _ when this == Lr => onLr(),
            _ when this == Ls => onLs(),
            _ when this == Lt => onLt(),
            _ when this == Lu => onLu(),
            _ when this == Lv => onLv(),
            _ when this == Ly => onLy(),
            _ when this == Ma => onMa(),
            _ when this == Mc => onMc(),
            _ when this == Md => onMd(),
            _ when this == Me => onMe(),
            _ when this == Mf => onMf(),
            _ when this == Mg => onMg(),
            _ when this == Mh => onMh(),
            _ when this == Mk => onMk(),
            _ when this == Ml => onMl(),
            _ when this == Mm => onMm(),
            _ when this == Mn => onMn(),
            _ when this == Mo => onMo(),
            _ when this == Mp => onMp(),
            _ when this == Mq => onMq(),
            _ when this == Mr => onMr(),
            _ when this == Ms => onMs(),
            _ when this == Mt => onMt(),
            _ when this == Mu => onMu(),
            _ when this == Mv => onMv(),
            _ when this == Mw => onMw(),
            _ when this == Mx => onMx(),
            _ when this == My => onMy(),
            _ when this == Mz => onMz(),
            _ when this == Na => onNa(),
            _ when this == Nc => onNc(),
            _ when this == Ne => onNe(),
            _ when this == Nf => onNf(),
            _ when this == Ng => onNg(),
            _ when this == Ni => onNi(),
            _ when this == Nl => onNl(),
            _ when this == No => onNo(),
            _ when this == Np => onNp(),
            _ when this == Nr => onNr(),
            _ when this == Nu => onNu(),
            _ when this == Nz => onNz(),
            _ when this == Om => onOm(),
            _ when this == Pa => onPa(),
            _ when this == Pe => onPe(),
            _ when this == Pf => onPf(),
            _ when this == Pg => onPg(),
            _ when this == Ph => onPh(),
            _ when this == Pk => onPk(),
            _ when this == Pl => onPl(),
            _ when this == Pm => onPm(),
            _ when this == Pn => onPn(),
            _ when this == Pr => onPr(),
            _ when this == Ps => onPs(),
            _ when this == Pt => onPt(),
            _ when this == Pw => onPw(),
            _ when this == Py => onPy(),
            _ when this == Qa => onQa(),
            _ when this == Re => onRe(),
            _ when this == Ro => onRo(),
            _ when this == Rs => onRs(),
            _ when this == Ru => onRu(),
            _ when this == Rw => onRw(),
            _ when this == Sa => onSa(),
            _ when this == Sb => onSb(),
            _ when this == Sc => onSc(),
            _ when this == Sd => onSd(),
            _ when this == Se => onSe(),
            _ when this == Sg => onSg(),
            _ when this == Sh => onSh(),
            _ when this == Si => onSi(),
            _ when this == Sj => onSj(),
            _ when this == Sk => onSk(),
            _ when this == Sl => onSl(),
            _ when this == Sm => onSm(),
            _ when this == Sn => onSn(),
            _ when this == So => onSo(),
            _ when this == Sr => onSr(),
            _ when this == Ss => onSs(),
            _ when this == St => onSt(),
            _ when this == Sv => onSv(),
            _ when this == Sx => onSx(),
            _ when this == Sy => onSy(),
            _ when this == Sz => onSz(),
            _ when this == Tc => onTc(),
            _ when this == Td => onTd(),
            _ when this == Tf => onTf(),
            _ when this == Tg => onTg(),
            _ when this == Th => onTh(),
            _ when this == Tj => onTj(),
            _ when this == Tk => onTk(),
            _ when this == Tl => onTl(),
            _ when this == Tm => onTm(),
            _ when this == Tn => onTn(),
            _ when this == To => onTo(),
            _ when this == Tr => onTr(),
            _ when this == Tt => onTt(),
            _ when this == Tv => onTv(),
            _ when this == Tw => onTw(),
            _ when this == Tz => onTz(),
            _ when this == Ua => onUa(),
            _ when this == Ug => onUg(),
            _ when this == Um => onUm(),
            _ when this == Us => onUs(),
            _ when this == Uy => onUy(),
            _ when this == Uz => onUz(),
            _ when this == Va => onVa(),
            _ when this == Vc => onVc(),
            _ when this == Ve => onVe(),
            _ when this == Vg => onVg(),
            _ when this == Vi => onVi(),
            _ when this == Vn => onVn(),
            _ when this == Vu => onVu(),
            _ when this == Wf => onWf(),
            _ when this == Ws => onWs(),
            _ when this == Xk => onXk(),
            _ when this == Ye => onYe(),
            _ when this == Yt => onYt(),
            _ when this == Za => onZa(),
            _ when this == Zm => onZm(),
            _ when this == Zw => onZw(),
            _ => otherwise(Value)
        };

    public void Match(Action onAd,
        Action onAe,
        Action onAf,
        Action onAg,
        Action onAi,
        Action onAl,
        Action onAm,
        Action onAo,
        Action onAq,
        Action onAr,
        Action onAs,
        Action onAt,
        Action onAu,
        Action onAw,
        Action onAx,
        Action onAz,
        Action onBa,
        Action onBb,
        Action onBd,
        Action onBe,
        Action onBf,
        Action onBg,
        Action onBh,
        Action onBi,
        Action onBj,
        Action onBl,
        Action onBm,
        Action onBn,
        Action onBo,
        Action onBq,
        Action onBr,
        Action onBs,
        Action onBt,
        Action onBv,
        Action onBw,
        Action onBy,
        Action onBz,
        Action onCa,
        Action onCc,
        Action onCd,
        Action onCf,
        Action onCg,
        Action onCh,
        Action onCi,
        Action onCk,
        Action onCl,
        Action onCm,
        Action onCn,
        Action onCo,
        Action onCr,
        Action onCu,
        Action onCv,
        Action onCw,
        Action onCx,
        Action onCy,
        Action onCz,
        Action onDe,
        Action onDj,
        Action onDk,
        Action onDm,
        Action onDo,
        Action onDz,
        Action onEc,
        Action onEe,
        Action onEg,
        Action onEh,
        Action onEr,
        Action onEs,
        Action onEt,
        Action onFi,
        Action onFj,
        Action onFk,
        Action onFm,
        Action onFo,
        Action onFr,
        Action onGa,
        Action onGb,
        Action onGd,
        Action onGe,
        Action onGf,
        Action onGg,
        Action onGh,
        Action onGi,
        Action onGl,
        Action onGm,
        Action onGn,
        Action onGp,
        Action onGq,
        Action onGr,
        Action onGs,
        Action onGt,
        Action onGu,
        Action onGw,
        Action onGy,
        Action onHk,
        Action onHm,
        Action onHn,
        Action onHr,
        Action onHt,
        Action onHu,
        Action onId,
        Action onIe,
        Action onIl,
        Action onIm,
        Action onIn,
        Action onIo,
        Action onIq,
        Action onIr,
        Action onIsMember,
        Action onIt,
        Action onJe,
        Action onJm,
        Action onJo,
        Action onJp,
        Action onKe,
        Action onKg,
        Action onKh,
        Action onKi,
        Action onKm,
        Action onKn,
        Action onKp,
        Action onKr,
        Action onKw,
        Action onKy,
        Action onKz,
        Action onLa,
        Action onLb,
        Action onLc,
        Action onLi,
        Action onLk,
        Action onLr,
        Action onLs,
        Action onLt,
        Action onLu,
        Action onLv,
        Action onLy,
        Action onMa,
        Action onMc,
        Action onMd,
        Action onMe,
        Action onMf,
        Action onMg,
        Action onMh,
        Action onMk,
        Action onMl,
        Action onMm,
        Action onMn,
        Action onMo,
        Action onMp,
        Action onMq,
        Action onMr,
        Action onMs,
        Action onMt,
        Action onMu,
        Action onMv,
        Action onMw,
        Action onMx,
        Action onMy,
        Action onMz,
        Action onNa,
        Action onNc,
        Action onNe,
        Action onNf,
        Action onNg,
        Action onNi,
        Action onNl,
        Action onNo,
        Action onNp,
        Action onNr,
        Action onNu,
        Action onNz,
        Action onOm,
        Action onPa,
        Action onPe,
        Action onPf,
        Action onPg,
        Action onPh,
        Action onPk,
        Action onPl,
        Action onPm,
        Action onPn,
        Action onPr,
        Action onPs,
        Action onPt,
        Action onPw,
        Action onPy,
        Action onQa,
        Action onRe,
        Action onRo,
        Action onRs,
        Action onRu,
        Action onRw,
        Action onSa,
        Action onSb,
        Action onSc,
        Action onSd,
        Action onSe,
        Action onSg,
        Action onSh,
        Action onSi,
        Action onSj,
        Action onSk,
        Action onSl,
        Action onSm,
        Action onSn,
        Action onSo,
        Action onSr,
        Action onSs,
        Action onSt,
        Action onSv,
        Action onSx,
        Action onSy,
        Action onSz,
        Action onTc,
        Action onTd,
        Action onTf,
        Action onTg,
        Action onTh,
        Action onTj,
        Action onTk,
        Action onTl,
        Action onTm,
        Action onTn,
        Action onTo,
        Action onTr,
        Action onTt,
        Action onTv,
        Action onTw,
        Action onTz,
        Action onUa,
        Action onUg,
        Action onUm,
        Action onUs,
        Action onUy,
        Action onUz,
        Action onVa,
        Action onVc,
        Action onVe,
        Action onVg,
        Action onVi,
        Action onVn,
        Action onVu,
        Action onWf,
        Action onWs,
        Action onXk,
        Action onYe,
        Action onYt,
        Action onZa,
        Action onZm,
        Action onZw,
        Action<string> otherwise)
    {
        if (this == Ad) onAd();
        else if (this == Ae) onAe();
        else if (this == Af) onAf();
        else if (this == Ag) onAg();
        else if (this == Ai) onAi();
        else if (this == Al) onAl();
        else if (this == Am) onAm();
        else if (this == Ao) onAo();
        else if (this == Aq) onAq();
        else if (this == Ar) onAr();
        else if (this == As) onAs();
        else if (this == At) onAt();
        else if (this == Au) onAu();
        else if (this == Aw) onAw();
        else if (this == Ax) onAx();
        else if (this == Az) onAz();
        else if (this == Ba) onBa();
        else if (this == Bb) onBb();
        else if (this == Bd) onBd();
        else if (this == Be) onBe();
        else if (this == Bf) onBf();
        else if (this == Bg) onBg();
        else if (this == Bh) onBh();
        else if (this == Bi) onBi();
        else if (this == Bj) onBj();
        else if (this == Bl) onBl();
        else if (this == Bm) onBm();
        else if (this == Bn) onBn();
        else if (this == Bo) onBo();
        else if (this == Bq) onBq();
        else if (this == Br) onBr();
        else if (this == Bs) onBs();
        else if (this == Bt) onBt();
        else if (this == Bv) onBv();
        else if (this == Bw) onBw();
        else if (this == By) onBy();
        else if (this == Bz) onBz();
        else if (this == Ca) onCa();
        else if (this == Cc) onCc();
        else if (this == Cd) onCd();
        else if (this == Cf) onCf();
        else if (this == Cg) onCg();
        else if (this == Ch) onCh();
        else if (this == Ci) onCi();
        else if (this == Ck) onCk();
        else if (this == Cl) onCl();
        else if (this == Cm) onCm();
        else if (this == Cn) onCn();
        else if (this == Co) onCo();
        else if (this == Cr) onCr();
        else if (this == Cu) onCu();
        else if (this == Cv) onCv();
        else if (this == Cw) onCw();
        else if (this == Cx) onCx();
        else if (this == Cy) onCy();
        else if (this == Cz) onCz();
        else if (this == De) onDe();
        else if (this == Dj) onDj();
        else if (this == Dk) onDk();
        else if (this == Dm) onDm();
        else if (this == Do) onDo();
        else if (this == Dz) onDz();
        else if (this == Ec) onEc();
        else if (this == Ee) onEe();
        else if (this == Eg) onEg();
        else if (this == Eh) onEh();
        else if (this == Er) onEr();
        else if (this == Es) onEs();
        else if (this == Et) onEt();
        else if (this == Fi) onFi();
        else if (this == Fj) onFj();
        else if (this == Fk) onFk();
        else if (this == Fm) onFm();
        else if (this == Fo) onFo();
        else if (this == Fr) onFr();
        else if (this == Ga) onGa();
        else if (this == Gb) onGb();
        else if (this == Gd) onGd();
        else if (this == Ge) onGe();
        else if (this == Gf) onGf();
        else if (this == Gg) onGg();
        else if (this == Gh) onGh();
        else if (this == Gi) onGi();
        else if (this == Gl) onGl();
        else if (this == Gm) onGm();
        else if (this == Gn) onGn();
        else if (this == Gp) onGp();
        else if (this == Gq) onGq();
        else if (this == Gr) onGr();
        else if (this == Gs) onGs();
        else if (this == Gt) onGt();
        else if (this == Gu) onGu();
        else if (this == Gw) onGw();
        else if (this == Gy) onGy();
        else if (this == Hk) onHk();
        else if (this == Hm) onHm();
        else if (this == Hn) onHn();
        else if (this == Hr) onHr();
        else if (this == Ht) onHt();
        else if (this == Hu) onHu();
        else if (this == Id) onId();
        else if (this == Ie) onIe();
        else if (this == Il) onIl();
        else if (this == Im) onIm();
        else if (this == In) onIn();
        else if (this == Io) onIo();
        else if (this == Iq) onIq();
        else if (this == Ir) onIr();
        else if (this == IsMember) onIsMember();
        else if (this == It) onIt();
        else if (this == Je) onJe();
        else if (this == Jm) onJm();
        else if (this == Jo) onJo();
        else if (this == Jp) onJp();
        else if (this == Ke) onKe();
        else if (this == Kg) onKg();
        else if (this == Kh) onKh();
        else if (this == Ki) onKi();
        else if (this == Km) onKm();
        else if (this == Kn) onKn();
        else if (this == Kp) onKp();
        else if (this == Kr) onKr();
        else if (this == Kw) onKw();
        else if (this == Ky) onKy();
        else if (this == Kz) onKz();
        else if (this == La) onLa();
        else if (this == Lb) onLb();
        else if (this == Lc) onLc();
        else if (this == Li) onLi();
        else if (this == Lk) onLk();
        else if (this == Lr) onLr();
        else if (this == Ls) onLs();
        else if (this == Lt) onLt();
        else if (this == Lu) onLu();
        else if (this == Lv) onLv();
        else if (this == Ly) onLy();
        else if (this == Ma) onMa();
        else if (this == Mc) onMc();
        else if (this == Md) onMd();
        else if (this == Me) onMe();
        else if (this == Mf) onMf();
        else if (this == Mg) onMg();
        else if (this == Mh) onMh();
        else if (this == Mk) onMk();
        else if (this == Ml) onMl();
        else if (this == Mm) onMm();
        else if (this == Mn) onMn();
        else if (this == Mo) onMo();
        else if (this == Mp) onMp();
        else if (this == Mq) onMq();
        else if (this == Mr) onMr();
        else if (this == Ms) onMs();
        else if (this == Mt) onMt();
        else if (this == Mu) onMu();
        else if (this == Mv) onMv();
        else if (this == Mw) onMw();
        else if (this == Mx) onMx();
        else if (this == My) onMy();
        else if (this == Mz) onMz();
        else if (this == Na) onNa();
        else if (this == Nc) onNc();
        else if (this == Ne) onNe();
        else if (this == Nf) onNf();
        else if (this == Ng) onNg();
        else if (this == Ni) onNi();
        else if (this == Nl) onNl();
        else if (this == No) onNo();
        else if (this == Np) onNp();
        else if (this == Nr) onNr();
        else if (this == Nu) onNu();
        else if (this == Nz) onNz();
        else if (this == Om) onOm();
        else if (this == Pa) onPa();
        else if (this == Pe) onPe();
        else if (this == Pf) onPf();
        else if (this == Pg) onPg();
        else if (this == Ph) onPh();
        else if (this == Pk) onPk();
        else if (this == Pl) onPl();
        else if (this == Pm) onPm();
        else if (this == Pn) onPn();
        else if (this == Pr) onPr();
        else if (this == Ps) onPs();
        else if (this == Pt) onPt();
        else if (this == Pw) onPw();
        else if (this == Py) onPy();
        else if (this == Qa) onQa();
        else if (this == Re) onRe();
        else if (this == Ro) onRo();
        else if (this == Rs) onRs();
        else if (this == Ru) onRu();
        else if (this == Rw) onRw();
        else if (this == Sa) onSa();
        else if (this == Sb) onSb();
        else if (this == Sc) onSc();
        else if (this == Sd) onSd();
        else if (this == Se) onSe();
        else if (this == Sg) onSg();
        else if (this == Sh) onSh();
        else if (this == Si) onSi();
        else if (this == Sj) onSj();
        else if (this == Sk) onSk();
        else if (this == Sl) onSl();
        else if (this == Sm) onSm();
        else if (this == Sn) onSn();
        else if (this == So) onSo();
        else if (this == Sr) onSr();
        else if (this == Ss) onSs();
        else if (this == St) onSt();
        else if (this == Sv) onSv();
        else if (this == Sx) onSx();
        else if (this == Sy) onSy();
        else if (this == Sz) onSz();
        else if (this == Tc) onTc();
        else if (this == Td) onTd();
        else if (this == Tf) onTf();
        else if (this == Tg) onTg();
        else if (this == Th) onTh();
        else if (this == Tj) onTj();
        else if (this == Tk) onTk();
        else if (this == Tl) onTl();
        else if (this == Tm) onTm();
        else if (this == Tn) onTn();
        else if (this == To) onTo();
        else if (this == Tr) onTr();
        else if (this == Tt) onTt();
        else if (this == Tv) onTv();
        else if (this == Tw) onTw();
        else if (this == Tz) onTz();
        else if (this == Ua) onUa();
        else if (this == Ug) onUg();
        else if (this == Um) onUm();
        else if (this == Us) onUs();
        else if (this == Uy) onUy();
        else if (this == Uz) onUz();
        else if (this == Va) onVa();
        else if (this == Vc) onVc();
        else if (this == Ve) onVe();
        else if (this == Vg) onVg();
        else if (this == Vi) onVi();
        else if (this == Vn) onVn();
        else if (this == Vu) onVu();
        else if (this == Wf) onWf();
        else if (this == Ws) onWs();
        else if (this == Xk) onXk();
        else if (this == Ye) onYe();
        else if (this == Yt) onYt();
        else if (this == Za) onZa();
        else if (this == Zm) onZm();
        else if (this == Zw) onZw();
        else otherwise(Value);
    }
}
