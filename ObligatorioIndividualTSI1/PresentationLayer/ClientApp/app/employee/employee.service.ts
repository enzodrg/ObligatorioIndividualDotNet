import { Injectable } from '@angular/core';
import { HttpModule, Http } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import { Data } from '@angular/router';
/**
 * Service for notify and subscribe to events.
 */
@Injectable()

export interface Employee {
    Name: string;
    Id: number;
    StartDate: Date;
    Salary: number;
    HourlyRate: number;
}

export class EmployeeService {
    constructor(private http: Http) {}
    public addEmployee(emp: Employee): Observable<Employee> {
        return this.http.post<Employee>('', emp);
    }

    public editEmployee() {

    }

    public getEmployees() {

    }
}
