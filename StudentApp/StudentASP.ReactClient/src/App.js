import React, { useEffect, useState } from "react";
import css from "./App.module.css";

function App() {
  const [error, setError] = useState(null);
  const [students, setStudent] = useState([]);

  function GetStudent() {
    const url = "https://localhost:5001/api/Student";

    fetch(url, {
      method: "GET",
      // headers: {
      //   "Content-Type": "application/json",
      // },
    })
      .then((response) => response.json())
      .then((studentsFromServer) => {
        console.log(studentsFromServer);
        setStudent(studentsFromServer.students);
      })
      .catch((error) => {
        console.log(error);
        alert(error);
      });
  }

  return (
    <div className="container">
      <div className="row min-vh-100">
        <div className="col d-flex flex-column justify-content-center align-item-center">
          <div className={css.body}>
            <h1>All students</h1>
            <div className="mt-5">
              <button
                onClick={GetStudent}
                className="btn btn-dark btn-lg w-100"
              >
                {" "}
                Get Students from server{" "}
              </button>
            </div>
            <div>{students.length > 0 && renderTable()}</div>
          </div>
        </div>
      </div>
    </div>
  );

  function renderTable() {
    return (
      <div className="table-responsive mt-4">
        <table className="table table-bordered border dark">
          <thead>
            <tr>
              <th scope="col">NumberGroup</th>
              <th scope="col">First Name</th>
              <th scope="col">Last Name</th>
              <th scope="col">Teacher classroom</th>
              <th scope="col">Average score</th>
              <th scope="col">Statistics</th>
            </tr>
          </thead>
          <tbody>
            {students.map((student) => (
              <tr key={student.numberGroup}>
                <th scope="row">{student.numberGroup}</th>
                <td>{student.firstName}</td>
                <td>{student.lastName}</td>
                <td>{student.teacher}</td>
                <td>{student.averageScore.toFixed(1)}</td>
                <td>
                  <button className="btn btn-dark btn-lg mx-3 my-3">
                    Statistics
                  </button>
                </td>
              </tr>
            ))}
          </tbody>
        </table>
      </div>
    );
  }
}

export default App;
