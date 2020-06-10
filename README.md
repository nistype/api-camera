# api-camera
API CAMERA RETRO HABBBO

### SQL

DROP TABLE IF EXISTS `camera_photos`;
CREATE TABLE `camera_photos` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `creator_id` int(11) NOT NULL,
  `creator_name` varchar(50) NOT NULL,
  `file_name` varchar(50) NOT NULL,
  `reports` int(11) NOT NULL DEFAULT '0',
  `deleted` enum('1','0') NOT NULL DEFAULT '0',
  `ip_address` varchar(50) NOT NULL,
  `created_at` bigint(20) NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=1 DEFAULT CHARSET=latin1

INSERT INTO `furniture` (`id`, `item_name`, `public_name`, `type`, `width`, `length`, `stack_height`, `can_stack`, `can_sit`, `is_walkable`, `sprite_id`, `allow_recycle`, `allow_trade`, `allow_marketplace_sell`, `allow_gift`, `allow_inventory_stack`, `interaction_type`, `behaviour_data`, `interaction_modes_count`, `vending_ids`, `height_adjustable`, `effect_id`, `wired_id`, `is_rare`, `clothing_id`, `extra_rot`) VALUES ('777954881', 'external_image_wallitem_poster', 'Photo', 'i', '1', '1', '0', '1', '0', '0', '777954881', '1', '1', '1', '1', '1', 'camera_picture', '0', '1', '0', '0', '0', '0', '0', '0', '0');

#### EXTERNAL VARIABLES

navigator.thumbnail.url_base=${image.library.url}/camera/navigator-thumbnail/hhus/
stories.image_url_base=${image.library.url}/camera/



