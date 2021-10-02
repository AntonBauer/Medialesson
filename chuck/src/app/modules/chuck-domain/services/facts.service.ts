import { Inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Fact } from './../models/fact.model';
import { FACTS_URL } from './../injection-tokens/injection-tokens';
import { Facts } from '../models/facts.model';

@Injectable({
  providedIn: 'root'
})
export class FactsService {

  constructor(
    @Inject(FACTS_URL) private readonly factsUrl: string,
    private readonly http: HttpClient) { }

  public loadCategories(): Promise<string[]> {
    return this.http.get<string[]>(`${this.factsUrl}/categories`).toPromise();
  }

  public getRandomFact(): Promise<Fact> {
    return this.http.get<Fact>(`${this.factsUrl}/random`).toPromise();
  }

  public getRandomFromCategory(category: string): Promise<Fact> {
    return this.http.get<Fact>(`${this.factsUrl}/random`, { params: { category } }).toPromise();
  }

  public async findFact(searchQuery: string): Promise<Fact | undefined> {
    const facts = await this.http.get<Facts>(`${this.factsUrl}/search`, { params: { query: searchQuery } }).toPromise();

    return facts.total > 0
      ? facts.result[0]
      : undefined;
  }
}
