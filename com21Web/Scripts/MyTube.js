/**
 * Mytube - Youtube player with playlist attached
 * @version		1.0.0
 * @MooTools version 1.2
 * @author Constantin Boiangiu <constantin.b [at] gmail.com>
 * @copyright Constantin Boiangiu
 * MIT-style license.
 */

var MyTube = new Class({
	Implements: [Options, YTPlayer],
	
	options: {
		playerConfig: {
			showRelated: 0, // youtube player can display related videos, search or info when video ends. Set any of these variables to 1 to display 
			showSearch: 0,
			showInfo: 0
		},
		messageLoading: null, // when playlist loads, you can set a message (ie: Loading... wait)
		onlyEmbeddable: true, // only embeddable videos
		defaultDisplay: 1 // 1: display playlist onLoad, 2: display player onLoad
	},
	
	initialize: function(options){
		
		this.setOptions(options);
		this.items = this.scanPage();
		if(!this.items) return;
		
		
		this.items.playlists.each(function(el, playlistId){
			
			var dataString = el.get('html').replace(/<!--|-->/g, '');
			var data = JSON.decode(dataString);
			el.empty();
			var url = 'http://gdata.youtube.com/feeds/api/';
			
			if(data.user){
				url+='users/'+data.user+'/uploads/?v=2&alt=json-in-script&orderby=published';
				if( data.list )
					url+='&max-results='+data.list;
			}else if(data.movies){
				url+='videos/?v=2&alt=json-in-script&orderby=published&q='+data.movies;
			}
			
			el.addClass('loading').set({'text':this.options.messageLoading||'Loading playlist, please wait...'});
			this.setToggle(playlistId);			
			
			new Request.JSONP({
				url: url + (this.options.onlyEmbeddable ? '&format=5':''),
				onComplete: function(data){
					var videos = data.feed.entry;
					el.removeClass('loading').empty();
					this.setPlaylist(videos, playlistId, el);					
				}.bind(this) // end of JSONP request complete method
				
			}).send();
			
		}.bind(this));// end of playlists.each		
	},
	
	setToggle: function(key){
		var s1 = new Fx.Slide(this.items.playlists[key]);
		var s2 = new Fx.Slide(this.items.players[key]);
		if( this.options.defaultDisplay == 1 ) s2.hide();
		else s1.hide();
		
		this.items.playlists[key].store('listFx', s1);
		this.items.playlists[key].store('playerFx', s2);
		
		this.items.togglers[key].addEvent('click', function(event){
			new Event(event).stop();
			s1.toggle().chain(function(){
				if(s1.open && $defined(this.swfObj))
					this.swfObj.pauseVideo();
			}.bind(this));
			s2.toggle();
		}.bind(this))
		
	},
	
	setPlaylist: function(videos, playlistId, el){
		var links = [];
		videos.each(function(video,i){
			
			if(i==0)
				this.setPlayer(video.media$group.yt$videoid.$t, playlistId);
			var link = new Element('a',{
				'href':'#',
				'title':video.media$group.media$title.$t,
				'class':'MyTube_Tippers',
				'rel':'Click to view',
				'styles':{
					'display':'block',
					'position':'relative',
					'background-image':'url('+video.media$group.media$thumbnail[0].url+')',
					'width':video.media$group.media$thumbnail[0].width,
					'height':video.media$group.media$thumbnail[0].height
				},
				'events':{
					click: function(event){
						new Event(event).stop();
						var listFx = this.items.playlists[playlistId].retrieve('listFx');
						var playerFx = this.items.playlists[playlistId].retrieve('playerFx');
						listFx.toggle();
						playerFx.toggle().chain(this.playNew.pass([video.media$group.yt$videoid.$t, playlistId], this.player) );						
					}.bind(this) 
				}
			});
			links[i] = new Element('div', { 'class':'MyTube_video' }).adopt(link);									
		
		}.bind(this));// end of videos.each					
		if( links.length>1 ){
			el.adopt(links);
			var myTips = new Tips('.MyTube_Tippers', {className : 'MyTube_Tips'});
		}
	},
	
	scanPage: function(){
		var players = $$('.MT_youtube_player');
		var playlists = $$('.MT_playlist');	
		var togglers = $$('.toggle');
		if( players.length == 0 ) return false;		
		return {'players':players, 'playlists': playlists, 'togglers': togglers};
	}
	
})

/* function triggered by the player after it loads */
function onYouTubePlayerReady(){
	var obj = document.getElementById('YTV_videoPlayer_0');
	YTVplayer.swfObj = obj;
}

window.addEvent('load', function(){	
	this.YTVplayer = new MyTube({
		messageLoading: 'Loading, please wait...',
		onlyEmbeddable: true,
		defaultDisplay: 1
	});	
}.bind(this));