import { Injectable, OnInit } from '@angular/core';
import { environment } from '../Environments/environment';
import { HttpClient } from '@angular/common/http';
import { PostCreateUpdateDto } from '../Model/Post/post-create-update-dto';
import { Observable } from 'rxjs';
import { PostViewDto } from '../Model/Post/post-view-dto';

@Injectable({
  providedIn: 'root'
})
export class PostService{

  private apiUrl : string = environment.apiUrl + '/Post/'
  
  constructor(private client : HttpClient) {
  }

  
  createPost(dto : PostCreateUpdateDto)
  {
    return this.client.post<PostViewDto>(this.apiUrl, dto, { withCredentials : true})
  }
  
  getAll() : Observable<PostViewDto[]>
  {
    return this.client.get<PostViewDto[]>(this.apiUrl + "GetAll")
  }
}
