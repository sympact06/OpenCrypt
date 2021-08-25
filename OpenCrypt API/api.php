<?php
$token = define(getenv('key'), false);

if($_GET["key"] == $token){
    return True;
}
else{
    return False;
}

