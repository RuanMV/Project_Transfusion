<!DOCTYPE html>
<html>
<head>
<style>
.button {
  background-color: #4CAF50;
  border: none;
  border-radius: 8px;
  box-shadow: 0 9px #999;
  color: white;
  padding: 15px 32px;
  text-align: center;
  text-decoration: none;
  display: inline-block;
  font-size: 16px;
  margin 4px 2px;
  cursor: pointer;
}
.button:hover
{
  background-color: #3E8E41
}
.button:active
{
  background-color: #3E8E41;
  box-shadow: 0 5px #666;
  transform: translateY(4px);
}
</style>
</head>
<body>

<h2>Click to Generate Code</h2>

<a href='rcg-proto.php?gen=true' class="button">Generate Code</a>

<?php
$code = array("X", "X", "X", "X", "X", "X", "X");
$codelength = count($code);
$generatedcode;

if(isset($_GET['gen']))
{
  generatecode();
}

function generatecode()
{
  for ($x = 0; $x < $GLOBALS['codelength']; $x++)
  {
    $y = rand(0, 25);
    switch ($y)
    {
      case 0:
        $code[$x] = "A";
        break;
      case 1:
        $code[$x] = "B";
        break;
      case 2:
        $code[$x] = "C";
        break;
      case 3:
        $code[$x] = "D";
        break;
      case 4:
        $code[$x] = "E";
        break;
      case 5:
        $code[$x] = "F";
        break;
      case 6:
        $code[$x] = "G";
        break;
      case 7:
        $code[$x] = "H";
        break;
      case 8:
        $code[$x] = "I";
        break;
      case 9:
        $code[$x] = "J";
        break;
      case 10:
        $code[$x] = "K";
        break;
      case 11:
        $code[$x] = "L";
        break;
      case 12:
        $code[$x] = "M";
        break;
      case 13:
        $code[$x] = "N";
        break;
      case 14:
        $code[$x] = "O";
        break;
      case 15:
        $code[$x] = "P";
        break;
      case 16:
        $code[$x] = "Q";
        break;
      case 17:
        $code[$x] = "R";
        break;
      case 18:
        $code[$x] = "S";
        break;
      case 19:
        $code[$x] = "T";
        break;
      case 20:
        $code[$x] = "U";
        break;
      case 21:
        $code[$x] = "V";
        break;
      case 22:
        $code[$x] = "W";
        break;
      case 23:
        $code[$x] = "X";
        break;
      case 24:
        $code[$x] = "Y";
        break;
      case 25:
        $code[$x] = "Z";
        break;
      default:
        $code[$x] = "X";
    }
  }
  $GLOBALS['generatedcode'] = $code[0] . $code[1] . $code[2] . $code[3] . $code[4] . $code[5] . $code[6];
  checksavecode();
  echo $GLOBALS['generatedcode'];
}

function checksavecode()
{
  $myfile = fopen("codelist.txt", "a") or die("Unable to open file!");
  while(!feof($myfile))
  {
    if(fgets($myfile) != $GLOBALS['generatedcode'])
    {
      fwrite($myfile, $GLOBALS['generatedcode']);
      fwrite($myfile, "\n");
      fclose($myfile);
      break;
    }
    else
    {
      fclose($myfile);
      generatecode();
    }
  }
}
?>

</body>
</html>