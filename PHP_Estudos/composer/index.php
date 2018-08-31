<?php
require_once 'vendor/autoload.php';

$gravatar = new \emberlabs\gravatarlib\Gravatar();
$gravatar->setAvatarSize(150);
echo '<img src="' . $gravatar->buildGravatarURL('seu@email.com') . '" width="150" height="150">';