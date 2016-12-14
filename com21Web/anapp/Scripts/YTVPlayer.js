/**
 * Mytube - Youtube player with playlist attached
 * @version		1.0.0
 * @MooTools version 1.2
 * @author Constantin Boiangiu <constantin.b [at] gmail.com>
 * @copyright Constantin Boiangiu
 * MIT-style license.
 */
var YTPlayer = new Class({
	setPlayer: function(video, player_id){
		
		var playerURL = 'http://www.youtube.com/v/'+
						 video+
						 '&enablejsapi=1&playerapiid=YTV_videoPlayer&rel='+
						 this.options.playerConfig.showRelated+
						 '&showsearch='+
						 this.options.playerConfig.showSearch+
						 '&showinfo='+this.options.playerConfig.showInfo;
		
		var containerS = this.items.players[player_id].getSize();
		
		this.swfObj = new Swiff(playerURL, {
			id: 'YTV_videoPlayer_'+player_id,
			container: this.items.players[player_id].get('id'),
			width: containerS.x,
			height: containerS.y,
			params: {
				wmode: 'transparent',
				allowScriptAccess: 'always'
			}
		});		
	},
	
	playNew: function(video, player_id){
		$('YTV_videoPlayer_'+player_id).cueVideoById(video);
		$('YTV_videoPlayer_'+player_id).playVideo();
		return false;
	}

})