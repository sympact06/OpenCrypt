<?php
$token = define(getenv('key'), false);

if($_POST["key"] == $token){
    return True;
}
else{
    return False;
}

