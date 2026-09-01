import { Component, OnInit } from '@angular/core';
import { PostCreateUpdateDto } from '../../Model/Post/post-create-update-dto';
import { PostViewDto } from '../../Model/Post/post-view-dto';
import { PostService } from '../../Services/post.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrl: './home.component.sass'
})
export class HomeComponent implements OnInit {

  newPost : PostCreateUpdateDto
  posts : PostViewDto[] = []

  constructor(private service : PostService) {
    this.newPost = new PostCreateUpdateDto()
  }
  ngOnInit(): void {
    this.getAll()
  }

  createPost()
  {
    return this.service.createPost(this.newPost).subscribe({
      next: response => {
        console.log(response)
        this.posts.push(response)
      }
      ,
      error: error => console.log(error)
    })
  }

  getAll() : void
  {
    this.service.getAll().subscribe({
      next : response => this.posts = response,
      error: () => console.log("Something went wrong")
    })
  }

}
