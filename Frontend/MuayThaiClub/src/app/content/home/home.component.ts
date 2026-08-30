import { Component } from '@angular/core';
import { PostCreateUpdateDto } from '../../Model/Post/post-create-update-dto';
import { PostViewDto } from '../../Model/Post/post-view-dto';
import { PostService } from '../../Services/post.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrl: './home.component.sass'
})
export class HomeComponent {

  newPost : PostCreateUpdateDto
  posts : PostViewDto[] = []

constructor(private service : PostService) {
  this.newPost = new PostCreateUpdateDto()
}

createPost()
{
  return this.service.createPost(this.newPost).subscribe({
    next: response => console.log(response),
    error: error => console.log(error)
  })
}

getAll() : PostViewDto[]
{
  return this.service.getAll()
}

}
