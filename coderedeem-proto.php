<?php declare(strict_types=1); ?>
<!DOCTYPE html>
<html>
<body>

<?php

// define variables and set to empty values
$clientcode = "";

if($_SERVER["REQUEST_METHOD"] == "POST")
{
    $clientcode = check_input($_POST["clientcode"]);
}

function check_input($data)
{
    $data = trim($data);
    $data = stripslashes($data);
    $data = htmlspecialchars($data);
    return $data;
}
?>

<h2>Redeem Code</h2>
<form method="post" action="<?php echo htmlspecialchars($_SERVER["PHP_SELF"]);?>">
Code: <input type="text" name="clientcode">
<br><br>
<input type="submit" name="redeem" value="Redeem">
</form>

<?php

checkcode($clientcode);

function checkcode($clcode)
{
    $codelistfile = fopen("codelist.txt", "r") or die("Unable to open file!");
    $redeemlistfile = fopen("redeemlist.txt", "a") or die("Unable to open file!");
    
    while(!feof($codelistfile))
    {
        #$strcodelist = fgets($codelistfile);
        $strcodelist = strval(fgets($codelistfile, 8));
        echo $strcodelist;
        echo strlen($strcodelist);
        
        if(strcmp($strcodelist, $clcode) == 0)
        {
            echo "Code exists!<br>";
            goto checkredeemlist;
        }
        
        if(feof($codelistfile))
        {
            echo "Code does not exist!<br>";
            break;
        }
    }
    fclose($codelistfile);

    checkredeemlist:
    while(!feof($redeemlistfile))
    {
        redeemstart:
        #$strredeemlist = fgets($redeemlistfile);
        $strredeemlist = strval(fgets($redeemlistfile, 8));
        echo $strredeemlist;
        echo strlen($strredeemlist);

        if(strcmp($strredeemlist, $clcode) == 0)
        {
            echo "Code already redeemed!<br>";
            goto redeemstart;
        }
        
        if(feof($redeemlistfile))
        {
            fwrite($redeemlistfile, $clcode);
            fwrite($redeemlistfile, "\n");
            echo "Code redeemed!" . "<br>";
            break;
        }
    }
    fclose($redeemlistfile);
}
?>

</body>
</html>