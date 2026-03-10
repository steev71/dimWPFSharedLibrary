using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Dim.WPF.Shared.Library.UI;

public partial class TileMenuItemControl : UserControl
{
    private int _clickHandlerCount;
    private string[] _wavePathData = [
        "M0,96L12.6,101.3C25.3,107,51,117,76,101.3C101.1,85,126,43,152,37.3C176.8,32,202,64,227,101.3C252.6,139,278,181,303,213.3C328.4,245,354,267,379,277.3C404.2,288,429,288,455,282.7C480,277,505,267,531,266.7C555.8,267,581,277,606,240C631.6,203,657,117,682,85.3C707.4,53,733,75,758,69.3C783.2,64,808,32,834,26.7C858.9,21,884,43,909,64C934.7,85,960,107,985,133.3C1010.5,160,1036,192,1061,176C1086.3,160,1112,96,1137,96C1162.1,96,1187,160,1213,202.7C1237.9,245,1263,267,1288,234.7C1313.7,203,1339,117,1364,96C1389.5,75,1415,117,1427,138.7L1440,160L1440,320L1427.4,320C1414.7,320,1389,320,1364,320C1338.9,320,1314,320,1288,320C1263.2,320,1238,320,1213,320C1187.4,320,1162,320,1137,320C1111.6,320,1086,320,1061,320C1035.8,320,1011,320,985,320C960,320,935,320,909,320C884.2,320,859,320,834,320C808.4,320,783,320,758,320C732.6,320,707,320,682,320C656.8,320,632,320,606,320C581.1,320,556,320,531,320C505.3,320,480,320,455,320C429.5,320,404,320,379,320C353.7,320,328,320,303,320C277.9,320,253,320,227,320C202.1,320,177,320,152,320C126.3,320,101,320,76,320C50.5,320,25,320,13,320L0,320Z",
        "M0,288L12.6,245.3C25.3,203,51,117,76,106.7C101.1,96,126,160,152,165.3C176.8,171,202,117,227,106.7C252.6,96,278,128,303,128C328.4,128,354,96,379,117.3C404.2,139,429,213,455,229.3C480,245,505,203,531,165.3C555.8,128,581,96,606,80C631.6,64,657,64,682,69.3C707.4,75,733,85,758,96C783.2,107,808,117,834,144C858.9,171,884,213,909,197.3C934.7,181,960,107,985,80C1010.5,53,1036,75,1061,69.3C1086.3,64,1112,32,1137,48C1162.1,64,1187,128,1213,133.3C1237.9,139,1263,85,1288,85.3C1313.7,85,1339,139,1364,144C1389.5,149,1415,107,1427,85.3L1440,64L1440,320L1427.4,320C1414.7,320,1389,320,1364,320C1338.9,320,1314,320,1288,320C1263.2,320,1238,320,1213,320C1187.4,320,1162,320,1137,320C1111.6,320,1086,320,1061,320C1035.8,320,1011,320,985,320C960,320,935,320,909,320C884.2,320,859,320,834,320C808.4,320,783,320,758,320C732.6,320,707,320,682,320C656.8,320,632,320,606,320C581.1,320,556,320,531,320C505.3,320,480,320,455,320C429.5,320,404,320,379,320C353.7,320,328,320,303,320C277.9,320,253,320,227,320C202.1,320,177,320,152,320C126.3,320,101,320,76,320C50.5,320,25,320,13,320L0,320Z",
        "M0,288L12.6,250.7C25.3,213,51,139,76,133.3C101.1,128,126,192,152,197.3C176.8,203,202,149,227,154.7C252.6,160,278,224,303,245.3C328.4,267,354,245,379,229.3C404.2,213,429,203,455,186.7C480,171,505,149,531,165.3C555.8,181,581,235,606,218.7C631.6,203,657,117,682,74.7C707.4,32,733,32,758,69.3C783.2,107,808,181,834,213.3C858.9,245,884,235,909,229.3C934.7,224,960,224,985,213.3C1010.5,203,1036,181,1061,149.3C1086.3,117,1112,75,1137,48C1162.1,21,1187,11,1213,26.7C1237.9,43,1263,85,1288,128C1313.7,171,1339,213,1364,213.3C1389.5,213,1415,171,1427,149.3L1440,128L1440,320L1427.4,320C1414.7,320,1389,320,1364,320C1338.9,320,1314,320,1288,320C1263.2,320,1238,320,1213,320C1187.4,320,1162,320,1137,320C1111.6,320,1086,320,1061,320C1035.8,320,1011,320,985,320C960,320,935,320,909,320C884.2,320,859,320,834,320C808.4,320,783,320,758,320C732.6,320,707,320,682,320C656.8,320,632,320,606,320C581.1,320,556,320,531,320C505.3,320,480,320,455,320C429.5,320,404,320,379,320C353.7,320,328,320,303,320C277.9,320,253,320,227,320C202.1,320,177,320,152,320C126.3,320,101,320,76,320C50.5,320,25,320,13,320L0,320Z",
        "M0,288L12,277.3C24,267,48,245,72,218.7C96,192,120,160,144,154.7C168,149,192,171,216,149.3C240,128,264,64,288,53.3C312,43,336,85,360,101.3C384,117,408,107,432,112C456,117,480,139,504,154.7C528,171,552,181,576,186.7C600,192,624,192,648,202.7C672,213,696,235,720,256C744,277,768,299,792,272C816,245,840,171,864,165.3C888,160,912,224,936,256C960,288,984,288,1008,256C1032,224,1056,160,1080,154.7C1104,149,1128,203,1152,234.7C1176,267,1200,277,1224,250.7C1248,224,1272,160,1296,122.7C1320,85,1344,75,1368,96C1392,117,1416,171,1428,197.3L1440,224L1440,320L1428,320C1416,320,1392,320,1368,320C1344,320,1320,320,1296,320C1272,320,1248,320,1224,320C1200,320,1176,320,1152,320C1128,320,1104,320,1080,320C1056,320,1032,320,1008,320C984,320,960,320,936,320C912,320,888,320,864,320C840,320,816,320,792,320C768,320,744,320,720,320C696,320,672,320,648,320C624,320,600,320,576,320C552,320,528,320,504,320C480,320,456,320,432,320C408,320,384,320,360,320C336,320,312,320,288,320C264,320,240,320,216,320C192,320,168,320,144,320C120,320,96,320,72,320C48,320,24,320,12,320L0,320Z",
        "M0,128L12,128C24,128,48,128,72,154.7C96,181,120,235,144,240C168,245,192,203,216,202.7C240,203,264,245,288,229.3C312,213,336,139,360,133.3C384,128,408,192,432,181.3C456,171,480,85,504,69.3C528,53,552,107,576,149.3C600,192,624,224,648,234.7C672,245,696,235,720,197.3C744,160,768,96,792,101.3C816,107,840,181,864,213.3C888,245,912,235,936,224C960,213,984,203,1008,192C1032,181,1056,171,1080,176C1104,181,1128,203,1152,213.3C1176,224,1200,224,1224,224C1248,224,1272,224,1296,213.3C1320,203,1344,181,1368,197.3C1392,213,1416,267,1428,293.3L1440,320L1440,320L1428,320C1416,320,1392,320,1368,320C1344,320,1320,320,1296,320C1272,320,1248,320,1224,320C1200,320,1176,320,1152,320C1128,320,1104,320,1080,320C1056,320,1032,320,1008,320C984,320,960,320,936,320C912,320,888,320,864,320C840,320,816,320,792,320C768,320,744,320,720,320C696,320,672,320,648,320C624,320,600,320,576,320C552,320,528,320,504,320C480,320,456,320,432,320C408,320,384,320,360,320C336,320,312,320,288,320C264,320,240,320,216,320C192,320,168,320,144,320C120,320,96,320,72,320C48,320,24,320,12,320L0,320Z",
        "M0,192L12,208C24,224,48,256,72,266.7C96,277,120,267,144,256C168,245,192,235,216,218.7C240,203,264,181,288,170.7C312,160,336,160,360,165.3C384,171,408,181,432,208C456,235,480,277,504,293.3C528,309,552,299,576,272C600,245,624,203,648,192C672,181,696,203,720,218.7C744,235,768,245,792,250.7C816,256,840,256,864,229.3C888,203,912,149,936,144C960,139,984,181,1008,208C1032,235,1056,245,1080,245.3C1104,245,1128,235,1152,224C1176,213,1200,203,1224,202.7C1248,203,1272,213,1296,234.7C1320,256,1344,288,1368,256C1392,224,1416,128,1428,80L1440,32L1440,320L1428,320C1416,320,1392,320,1368,320C1344,320,1320,320,1296,320C1272,320,1248,320,1224,320C1200,320,1176,320,1152,320C1128,320,1104,320,1080,320C1056,320,1032,320,1008,320C984,320,960,320,936,320C912,320,888,320,864,320C840,320,816,320,792,320C768,320,744,320,720,320C696,320,672,320,648,320C624,320,600,320,576,320C552,320,528,320,504,320C480,320,456,320,432,320C408,320,384,320,360,320C336,320,312,320,288,320C264,320,240,320,216,320C192,320,168,320,144,320C120,320,96,320,72,320C48,320,24,320,12,320L0,320Z",
        "M0,96L12,122.7C24,149,48,203,72,213.3C96,224,120,192,144,192C168,192,192,224,216,245.3C240,267,264,277,288,277.3C312,277,336,267,360,250.7C384,235,408,213,432,181.3C456,149,480,107,504,74.7C528,43,552,21,576,16C600,11,624,21,648,37.3C672,53,696,75,720,112C744,149,768,203,792,208C816,213,840,171,864,128C888,85,912,43,936,32C960,21,984,43,1008,64C1032,85,1056,107,1080,149.3C1104,192,1128,256,1152,277.3C1176,299,1200,277,1224,261.3C1248,245,1272,235,1296,208C1320,181,1344,139,1368,149.3C1392,160,1416,224,1428,256L1440,288L1440,320L1428,320C1416,320,1392,320,1368,320C1344,320,1320,320,1296,320C1272,320,1248,320,1224,320C1200,320,1176,320,1152,320C1128,320,1104,320,1080,320C1056,320,1032,320,1008,320C984,320,960,320,936,320C912,320,888,320,864,320C840,320,816,320,792,320C768,320,744,320,720,320C696,320,672,320,648,320C624,320,600,320,576,320C552,320,528,320,504,320C480,320,456,320,432,320C408,320,384,320,360,320C336,320,312,320,288,320C264,320,240,320,216,320C192,320,168,320,144,320C120,320,96,320,72,320C48,320,24,320,12,320L0,320Z",
        "M0,192L12.6,176C25.3,160,51,128,76,106.7C101.1,85,126,75,152,101.3C176.8,128,202,192,227,224C252.6,256,278,256,303,234.7C328.4,213,354,171,379,160C404.2,149,429,171,455,154.7C480,139,505,85,531,69.3C555.8,53,581,75,606,101.3C631.6,128,657,160,682,154.7C707.4,149,733,107,758,80C783.2,53,808,43,834,48C858.9,53,884,75,909,106.7C934.7,139,960,181,985,192C1010.5,203,1036,181,1061,186.7C1086.3,192,1112,224,1137,250.7C1162.1,277,1187,299,1213,293.3C1237.9,288,1263,256,1288,234.7C1313.7,213,1339,203,1364,181.3C1389.5,160,1415,128,1427,112L1440,96L1440,320L1427.4,320C1414.7,320,1389,320,1364,320C1338.9,320,1314,320,1288,320C1263.2,320,1238,320,1213,320C1187.4,320,1162,320,1137,320C1111.6,320,1086,320,1061,320C1035.8,320,1011,320,985,320C960,320,935,320,909,320C884.2,320,859,320,834,320C808.4,320,783,320,758,320C732.6,320,707,320,682,320C656.8,320,632,320,606,320C581.1,320,556,320,531,320C505.3,320,480,320,455,320C429.5,320,404,320,379,320C353.7,320,328,320,303,320C277.9,320,253,320,227,320C202.1,320,177,320,152,320C126.3,320,101,320,76,320C50.5,320,25,320,13,320L0,320Z",
        "M0,288L12.6,277.3C25.3,267,51,245,76,229.3C101.1,213,126,203,152,213.3C176.8,224,202,256,227,266.7C252.6,277,278,267,303,218.7C328.4,171,354,85,379,90.7C404.2,96,429,192,455,234.7C480,277,505,267,531,234.7C555.8,203,581,149,606,144C631.6,139,657,181,682,197.3C707.4,213,733,203,758,176C783.2,149,808,107,834,117.3C858.9,128,884,192,909,229.3C934.7,267,960,277,985,272C1010.5,267,1036,245,1061,224C1086.3,203,1112,181,1137,176C1162.1,171,1187,181,1213,186.7C1237.9,192,1263,192,1288,160C1313.7,128,1339,64,1364,58.7C1389.5,53,1415,107,1427,133.3L1440,160L1440,320L1427.4,320C1414.7,320,1389,320,1364,320C1338.9,320,1314,320,1288,320C1263.2,320,1238,320,1213,320C1187.4,320,1162,320,1137,320C1111.6,320,1086,320,1061,320C1035.8,320,1011,320,985,320C960,320,935,320,909,320C884.2,320,859,320,834,320C808.4,320,783,320,758,320C732.6,320,707,320,682,320C656.8,320,632,320,606,320C581.1,320,556,320,531,320C505.3,320,480,320,455,320C429.5,320,404,320,379,320C353.7,320,328,320,303,320C277.9,320,253,320,227,320C202.1,320,177,320,152,320C126.3,320,101,320,76,320C50.5,320,25,320,13,320L0,320Z",
        "M0,224L12.6,192C25.3,160,51,96,76,101.3C101.1,107,126,181,152,192C176.8,203,202,149,227,117.3C252.6,85,278,75,303,64C328.4,53,354,43,379,64C404.2,85,429,139,455,149.3C480,160,505,128,531,101.3C555.8,75,581,53,606,90.7C631.6,128,657,224,682,234.7C707.4,245,733,171,758,117.3C783.2,64,808,32,834,58.7C858.9,85,884,171,909,213.3C934.7,256,960,256,985,261.3C1010.5,267,1036,277,1061,266.7C1086.3,256,1112,224,1137,197.3C1162.1,171,1187,149,1213,165.3C1237.9,181,1263,235,1288,229.3C1313.7,224,1339,160,1364,154.7C1389.5,149,1415,203,1427,229.3L1440,256L1440,320L1427.4,320C1414.7,320,1389,320,1364,320C1338.9,320,1314,320,1288,320C1263.2,320,1238,320,1213,320C1187.4,320,1162,320,1137,320C1111.6,320,1086,320,1061,320C1035.8,320,1011,320,985,320C960,320,935,320,909,320C884.2,320,859,320,834,320C808.4,320,783,320,758,320C732.6,320,707,320,682,320C656.8,320,632,320,606,320C581.1,320,556,320,531,320C505.3,320,480,320,455,320C429.5,320,404,320,379,320C353.7,320,328,320,303,320C277.9,320,253,320,227,320C202.1,320,177,320,152,320C126.3,320,101,320,76,320C50.5,320,25,320,13,320L0,320Z",
        "M0,128L12.6,128C25.3,128,51,128,76,144C101.1,160,126,192,152,202.7C176.8,213,202,203,227,208C252.6,213,278,235,303,213.3C328.4,192,354,128,379,128C404.2,128,429,192,455,213.3C480,235,505,213,531,208C555.8,203,581,213,606,192C631.6,171,657,117,682,101.3C707.4,85,733,107,758,144C783.2,181,808,235,834,256C858.9,277,884,267,909,266.7C934.7,267,960,277,985,288C1010.5,299,1036,309,1061,309.3C1086.3,309,1112,299,1137,282.7C1162.1,267,1187,245,1213,229.3C1237.9,213,1263,203,1288,186.7C1313.7,171,1339,149,1364,117.3C1389.5,85,1415,43,1427,21.3L1440,0L1440,320L1427.4,320C1414.7,320,1389,320,1364,320C1338.9,320,1314,320,1288,320C1263.2,320,1238,320,1213,320C1187.4,320,1162,320,1137,320C1111.6,320,1086,320,1061,320C1035.8,320,1011,320,985,320C960,320,935,320,909,320C884.2,320,859,320,834,320C808.4,320,783,320,758,320C732.6,320,707,320,682,320C656.8,320,632,320,606,320C581.1,320,556,320,531,320C505.3,320,480,320,455,320C429.5,320,404,320,379,320C353.7,320,328,320,303,320C277.9,320,253,320,227,320C202.1,320,177,320,152,320C126.3,320,101,320,76,320C50.5,320,25,320,13,320L0,320Z",
        "M0,64L21.8,85.3C43.6,107,87,149,131,181.3C174.5,213,218,235,262,240C305.5,245,349,235,393,208C436.4,181,480,139,524,101.3C567.3,64,611,32,655,53.3C698.2,75,742,149,785,186.7C829.1,224,873,224,916,208C960,192,1004,160,1047,165.3C1090.9,171,1135,213,1178,202.7C1221.8,192,1265,128,1309,90.7C1352.7,53,1396,43,1418,37.3L1440,32L1440,320L1418.2,320C1396.4,320,1353,320,1309,320C1265.5,320,1222,320,1178,320C1134.5,320,1091,320,1047,320C1003.6,320,960,320,916,320C872.7,320,829,320,785,320C741.8,320,698,320,655,320C610.9,320,567,320,524,320C480,320,436,320,393,320C349.1,320,305,320,262,320C218.2,320,175,320,131,320C87.3,320,44,320,22,320L0,320Z",
        "M0,320L21.8,288C43.6,256,87,192,131,144C174.5,96,218,64,262,74.7C305.5,85,349,139,393,149.3C436.4,160,480,128,524,122.7C567.3,117,611,139,655,160C698.2,181,742,203,785,218.7C829.1,235,873,245,916,250.7C960,256,1004,256,1047,250.7C1090.9,245,1135,235,1178,197.3C1221.8,160,1265,96,1309,69.3C1352.7,43,1396,53,1418,58.7L1440,64L1440,320L1418.2,320C1396.4,320,1353,320,1309,320C1265.5,320,1222,320,1178,320C1134.5,320,1091,320,1047,320C1003.6,320,960,320,916,320C872.7,320,829,320,785,320C741.8,320,698,320,655,320C610.9,320,567,320,524,320C480,320,436,320,393,320C349.1,320,305,320,262,320C218.2,320,175,320,131,320C87.3,320,44,320,22,320L0,320Z",
        "M0,32L26.7,69.3C53.3,107,107,181,160,181.3C213.3,181,267,107,320,117.3C373.3,128,427,224,480,234.7C533.3,245,587,171,640,154.7C693.3,139,747,181,800,192C853.3,203,907,181,960,154.7C1013.3,128,1067,96,1120,69.3C1173.3,43,1227,21,1280,10.7C1333.3,0,1387,0,1413,0L1440,0L1440,320L1413.3,320C1386.7,320,1333,320,1280,320C1226.7,320,1173,320,1120,320C1066.7,320,1013,320,960,320C906.7,320,853,320,800,320C746.7,320,693,320,640,320C586.7,320,533,320,480,320C426.7,320,373,320,320,320C266.7,320,213,320,160,320C106.7,320,53,320,27,320L0,320Z",
        "M0,288L26.7,288C53.3,288,107,288,160,282.7C213.3,277,267,267,320,240C373.3,213,427,171,480,149.3C533.3,128,587,128,640,133.3C693.3,139,747,149,800,170.7C853.3,192,907,224,960,240C1013.3,256,1067,256,1120,245.3C1173.3,235,1227,213,1280,181.3C1333.3,149,1387,107,1413,85.3L1440,64L1440,320L1413.3,320C1386.7,320,1333,320,1280,320C1226.7,320,1173,320,1120,320C1066.7,320,1013,320,960,320C906.7,320,853,320,800,320C746.7,320,693,320,640,320C586.7,320,533,320,480,320C426.7,320,373,320,320,320C266.7,320,213,320,160,320C106.7,320,53,320,27,320L0,320Z",
        "M0,64L9.2,58.7C18.5,53,37,43,55,80C73.8,117,92,203,111,250.7C129.2,299,148,309,166,277.3C184.6,245,203,171,222,160C240,149,258,203,277,202.7C295.4,203,314,149,332,128C350.8,107,369,117,388,138.7C406.2,160,425,192,443,224C461.5,256,480,288,498,277.3C516.9,267,535,213,554,170.7C572.3,128,591,96,609,90.7C627.7,85,646,107,665,128C683.1,149,702,171,720,186.7C738.5,203,757,213,775,197.3C793.8,181,812,139,831,106.7C849.2,75,868,53,886,74.7C904.6,96,923,160,942,181.3C960,203,978,181,997,192C1015.4,203,1034,245,1052,256C1070.8,267,1089,245,1108,213.3C1126.2,181,1145,139,1163,138.7C1181.5,139,1200,181,1218,176C1236.9,171,1255,117,1274,80C1292.3,43,1311,21,1329,42.7C1347.7,64,1366,128,1385,176C1403.1,224,1422,256,1431,272L1440,288L1440,320L1430.8,320C1421.5,320,1403,320,1385,320C1366.2,320,1348,320,1329,320C1310.8,320,1292,320,1274,320C1255.4,320,1237,320,1218,320C1200,320,1182,320,1163,320C1144.6,320,1126,320,1108,320C1089.2,320,1071,320,1052,320C1033.8,320,1015,320,997,320C978.5,320,960,320,942,320C923.1,320,905,320,886,320C867.7,320,849,320,831,320C812.3,320,794,320,775,320C756.9,320,738,320,720,320C701.5,320,683,320,665,320C646.2,320,628,320,609,320C590.8,320,572,320,554,320C535.4,320,517,320,498,320C480,320,462,320,443,320C424.6,320,406,320,388,320C369.2,320,351,320,332,320C313.8,320,295,320,277,320C258.5,320,240,320,222,320C203.1,320,185,320,166,320C147.7,320,129,320,111,320C92.3,320,74,320,55,320C36.9,320,18,320,9,320L0,320Z",
        "M0,224L9.2,218.7C18.5,213,37,203,55,170.7C73.8,139,92,85,111,96C129.2,107,148,181,166,202.7C184.6,224,203,192,222,149.3C240,107,258,53,277,53.3C295.4,53,314,107,332,117.3C350.8,128,369,96,388,106.7C406.2,117,425,171,443,213.3C461.5,256,480,288,498,282.7C516.9,277,535,235,554,186.7C572.3,139,591,85,609,96C627.7,107,646,181,665,208C683.1,235,702,213,720,186.7C738.5,160,757,128,775,106.7C793.8,85,812,75,831,69.3C849.2,64,868,64,886,58.7C904.6,53,923,43,942,80C960,117,978,203,997,234.7C1015.4,267,1034,245,1052,250.7C1070.8,256,1089,288,1108,293.3C1126.2,299,1145,277,1163,245.3C1181.5,213,1200,171,1218,144C1236.9,117,1255,107,1274,101.3C1292.3,96,1311,96,1329,122.7C1347.7,149,1366,203,1385,197.3C1403.1,192,1422,128,1431,96L1440,64L1440,320L1430.8,320C1421.5,320,1403,320,1385,320C1366.2,320,1348,320,1329,320C1310.8,320,1292,320,1274,320C1255.4,320,1237,320,1218,320C1200,320,1182,320,1163,320C1144.6,320,1126,320,1108,320C1089.2,320,1071,320,1052,320C1033.8,320,1015,320,997,320C978.5,320,960,320,942,320C923.1,320,905,320,886,320C867.7,320,849,320,831,320C812.3,320,794,320,775,320C756.9,320,738,320,720,320C701.5,320,683,320,665,320C646.2,320,628,320,609,320C590.8,320,572,320,554,320C535.4,320,517,320,498,320C480,320,462,320,443,320C424.6,320,406,320,388,320C369.2,320,351,320,332,320C313.8,320,295,320,277,320C258.5,320,240,320,222,320C203.1,320,185,320,166,320C147.7,320,129,320,111,320C92.3,320,74,320,55,320C36.9,320,18,320,9,320L0,320Z"
    ];

    public static readonly RoutedEvent ClickEvent = EventManager.RegisterRoutedEvent(
        nameof(Click),
        RoutingStrategy.Bubble,
        typeof(RoutedEventHandler),
        typeof(TileMenuItemControl));

    public event RoutedEventHandler Click
    {
        add
        {
            AddHandler(ClickEvent, value);
            _clickHandlerCount++;
            UpdateInteractivity();
        }
        remove
        {
            RemoveHandler(ClickEvent, value);
            if (_clickHandlerCount > 0)
                _clickHandlerCount--;
            UpdateInteractivity();
        }
    }

    public TileMenuItemControl()
    {
        InitializeComponent();

        RootButton.Click += (_, _) => RaiseEvent(new RoutedEventArgs(ClickEvent, this));
        UpdateHeaderVisibility();
        
        // Randomize wave path opacities when control loads
        Loaded += OnLoaded;
    }

    private void OnLoaded(object sender, RoutedEventArgs e)
    {
        // Ensure template is applied before accessing named elements
        RootButton.ApplyTemplate();
        
        // Load random wave paths from predefined array
        LoadRandomWavePathsFromArray();
    }

    /// <summary>
    /// Betölt 4 véletlenszerű wave path-ot a _wavePathData tömbből.
    /// </summary>
    private void LoadRandomWavePathsFromArray()
    {
        var random = new Random();
        
        // Select 4 random indices from the array (without duplicates)
        var availableIndices = Enumerable.Range(0, _wavePathData.Length).ToList();
        var selectedIndices = new List<int>();
        
        for (int i = 0; i < 4 && availableIndices.Count > 0; i++)
        {
            var randomIndex = random.Next(availableIndices.Count);
            selectedIndices.Add(availableIndices[randomIndex]);
            availableIndices.RemoveAt(randomIndex);
        }
        
        // Generate random opacities
        var opacities = new double[]
        {
            0.05 + random.NextDouble() * 0.20,
            0.05 + random.NextDouble() * 0.20,
            0.05 + random.NextDouble() * 0.20,
            0.05 + random.NextDouble() * 0.20
        };
        
        // Find wave paths by name
        var wavePath1 = RootButton.Template?.FindName("WavePath1", RootButton) as FrameworkElement;
        var wavePath2 = RootButton.Template?.FindName("WavePath2", RootButton) as FrameworkElement;
        var wavePath3 = RootButton.Template?.FindName("WavePath3", RootButton) as FrameworkElement;
        var wavePath4 = RootButton.Template?.FindName("WavePath4", RootButton) as FrameworkElement;
        
        // Update path data and opacity
        if (wavePath1 is Viewbox vb1 && vb1.Child is System.Windows.Shapes.Path p1 && selectedIndices.Count > 0)
        {
            p1.Data = Geometry.Parse(_wavePathData[selectedIndices[0]]);
            vb1.Opacity = opacities[0];
        }
        
        if (wavePath2 is Viewbox vb2 && vb2.Child is System.Windows.Shapes.Path p2 && selectedIndices.Count > 1)
        {
            p2.Data = Geometry.Parse(_wavePathData[selectedIndices[1]]);
            vb2.Opacity = opacities[1];
        }
        
        if (wavePath3 is Viewbox vb3 && vb3.Child is System.Windows.Shapes.Path p3 && selectedIndices.Count > 2)
        {
            p3.Data = Geometry.Parse(_wavePathData[selectedIndices[2]]);
            vb3.Opacity = opacities[2];
        }
        
        if (wavePath4 is Viewbox vb4 && vb4.Child is System.Windows.Shapes.Path p4 && selectedIndices.Count > 3)
        {
            p4.Data = Geometry.Parse(_wavePathData[selectedIndices[3]]);
            vb4.Opacity = opacities[3];
        }
    }

    public static readonly DependencyProperty CommandProperty =
        DependencyProperty.Register(
            nameof(Command),
            typeof(ICommand),
            typeof(TileMenuItemControl),
            new PropertyMetadata(null, OnInteractivityChanged));

    public ICommand? Command
    {
        get => (ICommand?)GetValue(CommandProperty);
        set => SetValue(CommandProperty, value);
    }

    public static readonly DependencyProperty CommandParameterProperty =
        DependencyProperty.Register(
            nameof(CommandParameter),
            typeof(object),
            typeof(TileMenuItemControl),
            new PropertyMetadata(null));

    public object? CommandParameter
    {
        get => GetValue(CommandParameterProperty);
        set => SetValue(CommandParameterProperty, value);
    }

    public static readonly DependencyProperty ShowArrowProperty =
        DependencyProperty.Register(
            nameof(ShowArrow),
            typeof(bool),
            typeof(TileMenuItemControl),
            new PropertyMetadata(true)); // Alapértelmezett érték: true

    public bool ShowArrow
    {
        get => (bool)GetValue(ShowArrowProperty);
        private set => SetValue(ShowArrowProperty, value);
    }

    public static readonly DependencyProperty HeaderBackgroundProperty =
        DependencyProperty.Register(
            nameof(HeaderBackground),
            typeof(Brush),
            typeof(TileMenuItemControl),
            new PropertyMetadata(Brushes.SteelBlue));

    public Brush HeaderBackground
    {
        get => (Brush)GetValue(HeaderBackgroundProperty);
        set => SetValue(HeaderBackgroundProperty, value);
    }

    public static readonly DependencyProperty HeaderIconProperty =
        DependencyProperty.Register(
            nameof(HeaderIcon),
            typeof(ImageSource),
            typeof(TileMenuItemControl),
            new PropertyMetadata(null, OnHeaderIconChanged));

    public ImageSource? HeaderIcon
    {
        get => (ImageSource?)GetValue(HeaderIconProperty);
        set => SetValue(HeaderIconProperty, value);
    }

    public static readonly DependencyProperty HeaderIconPathDataProperty =
        DependencyProperty.Register(
            nameof(HeaderIconPathData),
            typeof(string),
            typeof(TileMenuItemControl),
            new PropertyMetadata(string.Empty, OnHeaderIconChanged));

    public string HeaderIconPathData
    {
        get => (string)GetValue(HeaderIconPathDataProperty);
        set => SetValue(HeaderIconPathDataProperty, value);
    }

    public static readonly DependencyProperty HeaderLottieSourceProperty =
        DependencyProperty.Register(
            nameof(HeaderLottieSource),
            typeof(string),
            typeof(TileMenuItemControl),
            new PropertyMetadata(string.Empty, OnHeaderIconChanged));

    public string HeaderLottieSource
    {
        get => (string)GetValue(HeaderLottieSourceProperty);
        set => SetValue(HeaderLottieSourceProperty, value);
    }

    public static readonly DependencyProperty HeaderIconForegroundProperty =
        DependencyProperty.Register(
            nameof(HeaderIconForeground),
            typeof(Brush),
            typeof(TileMenuItemControl),
            new PropertyMetadata(Brushes.White));

    public Brush HeaderIconForeground
    {
        get => (Brush)GetValue(HeaderIconForegroundProperty);
        set => SetValue(HeaderIconForegroundProperty, value);
    }

    public static readonly DependencyProperty HeaderIconSizeProperty =
        DependencyProperty.Register(
            nameof(HeaderIconSize),
            typeof(double),
            typeof(TileMenuItemControl),
            new PropertyMetadata(32d));

    public double HeaderIconSize
    {
        get => (double)GetValue(HeaderIconSizeProperty);
        set => SetValue(HeaderIconSizeProperty, value);
    }

    public static readonly DependencyProperty IsHeaderIconVisibleProperty =
        DependencyProperty.Register(
            nameof(IsHeaderIconVisible),
            typeof(bool),
            typeof(TileMenuItemControl),
            new PropertyMetadata(false));

    public bool IsHeaderIconVisible
    {
        get => (bool)GetValue(IsHeaderIconVisibleProperty);
        private set => SetValue(IsHeaderIconVisibleProperty, value);
    }

    public static readonly DependencyProperty IsHeaderImageIconVisibleProperty =
        DependencyProperty.Register(
            nameof(IsHeaderImageIconVisible),
            typeof(bool),
            typeof(TileMenuItemControl),
            new PropertyMetadata(false));

    public bool IsHeaderImageIconVisible
    {
        get => (bool)GetValue(IsHeaderImageIconVisibleProperty);
        private set => SetValue(IsHeaderImageIconVisibleProperty, value);
    }

    public static readonly DependencyProperty IsHeaderPathIconVisibleProperty =
        DependencyProperty.Register(
            nameof(IsHeaderPathIconVisible),
            typeof(bool),
            typeof(TileMenuItemControl),
            new PropertyMetadata(false));

    public bool IsHeaderPathIconVisible
    {
        get => (bool)GetValue(IsHeaderPathIconVisibleProperty);
        private set => SetValue(IsHeaderPathIconVisibleProperty, value);
    }

    public static readonly DependencyProperty IsHeaderLottieIconVisibleProperty =
        DependencyProperty.Register(
            nameof(IsHeaderLottieIconVisible),
            typeof(bool),
            typeof(TileMenuItemControl),
            new PropertyMetadata(false));

    public bool IsHeaderLottieIconVisible
    {
        get => (bool)GetValue(IsHeaderLottieIconVisibleProperty);
        private set => SetValue(IsHeaderLottieIconVisibleProperty, value);
    }

    public static readonly DependencyProperty HeaderTextProperty =
        DependencyProperty.Register(
            nameof(HeaderText),
            typeof(string),
            typeof(TileMenuItemControl),
            new PropertyMetadata(string.Empty, OnHeaderTextChanged));

    public string HeaderText
    {
        get => (string)GetValue(HeaderTextProperty);
        set => SetValue(HeaderTextProperty, value);
    }

    public static readonly DependencyProperty HeaderTextColorProperty =
        DependencyProperty.Register(
            nameof(HeaderTextColor),
            typeof(Brush),
            typeof(TileMenuItemControl),
            new PropertyMetadata(Brushes.White));

    public Brush HeaderTextColor
    {
        get => (Brush)GetValue(HeaderTextColorProperty);
        set => SetValue(HeaderTextColorProperty, value);
    }

    public static readonly DependencyProperty IsHeaderTextVisibleProperty =
        DependencyProperty.Register(
            nameof(IsHeaderTextVisible),
            typeof(bool),
            typeof(TileMenuItemControl),
            new PropertyMetadata(false));

    public bool IsHeaderTextVisible
    {
        get => (bool)GetValue(IsHeaderTextVisibleProperty);
        private set => SetValue(IsHeaderTextVisibleProperty, value);
    }

    public static readonly DependencyProperty TitleTextProperty =
        DependencyProperty.Register(
            nameof(TitleText),
            typeof(string),
            typeof(TileMenuItemControl),
            new PropertyMetadata(string.Empty));

    public string TitleText
    {
        get => (string)GetValue(TitleTextProperty);
        set => SetValue(TitleTextProperty, value);
    }

    public static readonly DependencyProperty TitleColorProperty =
        DependencyProperty.Register(
            nameof(TitleColor),
            typeof(Brush),
            typeof(TileMenuItemControl),
            new PropertyMetadata(Brushes.Black));

    public Brush TitleColor
    {
        get => (Brush)GetValue(TitleColorProperty);
        set => SetValue(TitleColorProperty, value);
    }

    public static readonly DependencyProperty DescriptionTextProperty =
        DependencyProperty.Register(
            nameof(DescriptionText),
            typeof(string),
            typeof(TileMenuItemControl),
            new PropertyMetadata(string.Empty));

    public string DescriptionText
    {
        get => (string)GetValue(DescriptionTextProperty);
        set => SetValue(DescriptionTextProperty, value);
    }

    public static readonly DependencyProperty DescriptionColorProperty =
        DependencyProperty.Register(
            nameof(DescriptionColor),
            typeof(Brush),
            typeof(TileMenuItemControl),
            new PropertyMetadata(Brushes.Gray));

    public Brush DescriptionColor
    {
        get => (Brush)GetValue(DescriptionColorProperty);
        set => SetValue(DescriptionColorProperty, value);
    }

    private static void OnInteractivityChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        if (d is TileMenuItemControl control)
            control.UpdateInteractivity();
    }

    private void UpdateInteractivity()
    {
        ShowArrow = Command is not null || _clickHandlerCount > 0;
    }

    private static void OnHeaderIconChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        if (d is TileMenuItemControl control)
            control.UpdateHeaderVisibility();
    }

    private static void OnHeaderTextChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        if (d is TileMenuItemControl control)
            control.UpdateHeaderVisibility();
    }

    private void UpdateHeaderVisibility()
    {
        var hasImage = HeaderIcon is not null;
        var hasPath = !string.IsNullOrWhiteSpace(HeaderIconPathData);
        var hasLottie = !string.IsNullOrWhiteSpace(HeaderLottieSource);

        // Priority: Image > Lottie > Path
        IsHeaderImageIconVisible = hasImage;
        IsHeaderLottieIconVisible = !hasImage && hasLottie;
        IsHeaderPathIconVisible = !hasImage && !hasLottie && hasPath;
        IsHeaderIconVisible = IsHeaderImageIconVisible || IsHeaderPathIconVisible || IsHeaderLottieIconVisible;
        IsHeaderTextVisible = !string.IsNullOrWhiteSpace(HeaderText);
    }
}

