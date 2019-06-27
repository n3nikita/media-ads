import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ChannelsService } from 'src/app/services/channels.service';
import { Channel } from 'src/app/models/channel';
import { Title } from '@angular/platform-browser';

@Component({
  selector: 'app-details',
  templateUrl: './details.component.html',
  styleUrls: ['./details.component.scss']
})
export class DetailsComponent implements OnInit {

  channelLink: string;
  channel: Channel;

  view = [550, 300];
  
  colorScheme = {
    domain: ['#000000']
  };

  subs = [
    {
      "name": "Подписчики",
      "series": [
        {
          "name": "2010",
          "value": 10000
        },
        {
          "name": "2011",
          "value": 12000
        },
        {
          "name": "2012",
          "value": 13000
        },
        {
          "name": "2013",
          "value": 12000
        },
        {
          "name": "2014",
          "value": 13000
        },
        {
          "name": "2015",
          "value": 13000
        },
        {
          "name": "2016",
          "value": 15000
        },
        {
          "name": "2017",
          "value": 16000
        }
      ]
    },
  ];

  views = [
    {
      "name": "Просмотры",
      "series": [
        {
          "name": "2010",
          "value": 25000
        },
        {
          "name": "2011",
          "value": 27000
        },
        {
          "name": "2012",
          "value": 19000
        },
        {
          "name": "2013",
          "value": 17000
        },
        {
          "name": "2014",
          "value": 34000
        },
        {
          "name": "2015",
          "value": 30000
        },
        {
          "name": "2016",
          "value": 28000
        },
        {
          "name": "2017",
          "value": 24000
        }
      ]
    },
  ];

  dayViews = [
    {
      "name": "Просмотры за стуки",
      "series": [
        {
          "name": "2010",
          "value": 2000
        },
        {
          "name": "2011",
          "value": 3000
        },
        {
          "name": "2012",
          "value": 3500
        },
        {
          "name": "2013",
          "value": 3200
        },
        {
          "name": "2014",
          "value": 3800
        },
        {
          "name": "2015",
          "value": 4000
        },
        {
          "name": "2016",
          "value": 4900
        },
        {
          "name": "2017",
          "value": 4500
        }
      ]
    },
  ];

  multi2 = [
    {
      "name": "18 мая",
      "value": 5
    },
    {
      "name": "19 мая",
      "value": 1
    },
    {
      "name": "20 мая",
      "value": 0
    },
    {
      "name": "21 мая",
      "value": 3
    },
    {
      "name": "22 мая",
      "value": 1
    },
    {
      "name": "23 мая",
      "value": 5
    },
    {
      "name": "24 мая",
      "value": 1
    },
    {
      "name": "25 мая",
      "value": 0
    },
    {
      "name": "26 мая",
      "value": 3
    },
    {
      "name": "27 мая",
      "value": 1
    },
  ]

  constructor(private route: ActivatedRoute, private channelService: ChannelsService, private title: Title) { }

  ngOnInit() {
    this.route.params.subscribe(params => {
      this.channelLink = params['link'];
      this.channelService.getChannelByLink(this.channelLink).subscribe(data => {
        this.channel = data;
        this.title.setTitle(this.channel.name + ' | Media Ads');
      });
    });
  }

  numWithSpaces(x: number) {
    return x.toString().replace(/\B(?=(\d{3})+(?!\d))/g, " ");
  }

  
}
