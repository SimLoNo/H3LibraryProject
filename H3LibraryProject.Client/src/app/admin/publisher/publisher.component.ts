import { Component, OnInit } from '@angular/core';
import { Publisher } from 'src/app/_models/publisher';
import { PublisherService } from 'src/app/_services/publisher.service';

@Component({
  selector: 'app-publisher',
  templateUrl: './publisher.component.html',
  styleUrls: ['./publisher.component.css']
})
export class PublisherComponent implements OnInit {
  adminPages:string[] = ['author','genre','language','loan','loaner','loanertype','location','material','nationality','publisher','title'];
  publishers:Publisher[] = [];
  currentPublisher:Publisher = {publisherId:0,name:""};
  constructor(private publisherService: PublisherService) { }


  ngOnInit(): void {
    this.publisherService.readAllPublishers()
    .subscribe((data) => {
      console.log(data);
      if (data != null) {
        this.publishers = data;
      }

    })
  }
  edit(publisher:Publisher){
    console.log("selected publisher: " + publisher.name);

    this.currentPublisher = publisher;
  }

  deletePublisher(){
    if (confirm(`Er du sikker på at du vil slette sproget: ${this.currentPublisher.name}?`)) {
      this.publisherService.deletePublisher(this.currentPublisher.publisherId)
      .subscribe(data => {
        console.log(`Deleted data is: ${data.publisherId} ${data.name}`);
        this.publishers = this.publishers.filter(publisherObj => publisherObj.publisherId != this.currentPublisher.publisherId);
        this.reset();
      })
    }

  }

  savePublisher(){
  if (this.currentPublisher.publisherId <= 0 || this.currentPublisher.publisherId == null) {
      this.publisherService.createPublisher(this.currentPublisher)
      .subscribe(data => {
        console.log(`Save created new publisher: ${data.publisherId} ${data.name}`);
        this.publishers.push(data);
        this.reset();
      })
    }
    else {
      this.publisherService.updatePublisher(this.currentPublisher.publisherId, this.currentPublisher)
      .subscribe(data =>{
        console.log(`Save updated existing publisher: ${data.publisherId} ${data.name}`);
        let publisherIndex:number = this.publishers.findIndex(publisherObj => publisherObj.publisherId == this.currentPublisher.publisherId);
        this.publishers[publisherIndex] = data;
        this.reset();
      })
    }

  }

  reset(){
    this.currentPublisher = {publisherId:0, name:""};
  }
}
