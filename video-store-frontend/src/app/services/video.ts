import { Injectable } from '@angular/core';
import { HttpClient, HttpEvent, HttpRequest } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Video, VideoUploadResponse } from '../models';

@Injectable({
  providedIn: 'root',
})
export class VideoService {
  private readonly videosEndpoint = '/videos';

  constructor(private httpClient: HttpClient) {}

  getVideos(): Observable<Video[]> {
    return this.httpClient.get<Video[]>(this.videosEndpoint);
  }

  getVideoById(videoId: number): Observable<Video> {
    return this.httpClient.get<Video>(`${this.videosEndpoint}/${videoId}`);
  }

  uploadVideo(
    title: string,
    description: string,
    categoryIds: number[],
    videoFile: File
  ): Observable<HttpEvent<VideoUploadResponse>> {
    const formData = new FormData();
    formData.append('title', title);
    formData.append('description', description);
    categoryIds.forEach(categoryId => {
      formData.append('categoryIds', categoryId.toString());
    });
    formData.append('file', videoFile, videoFile.name);

    const uploadRequest = new HttpRequest<FormData>(
      'POST',
      this.videosEndpoint,
      formData,
      {
        reportProgress: true
      }
    );

    return this.httpClient.request<VideoUploadResponse>(uploadRequest);
  }

  getVideoStreamUrl(videoId: number): string {
    return `${this.videosEndpoint}/${videoId}/stream`;
  }
}
