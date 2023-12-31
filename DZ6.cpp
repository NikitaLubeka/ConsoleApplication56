#include <iostream>
#include <vector>

using namespace std;

class Task {
public:
    Task(string description, bool status, string deadline)
        : description(description), status(status), deadline(deadline) {}

    void changeStatus() {
        status = !status;
    }

    string getDescription() const {
        return description;
    }

    bool getStatus() const {
        return status;
    }

    string getDeadline() const {
        return deadline;
    }

private:
    string description;
    bool status;
    string deadline;
};

class Project {
public:
    Project(string name, string description, string startDate, string endDate)
        : name(name), description(description), startDate(startDate), endDate(endDate) {}

    void addTask(const Task& task) {
        tasks.push_back(task);
    }

    void removeTask(const string& description) {
        auto it = remove_if(tasks.begin(), tasks.end(), [&description](const Task& task) {
            return task.getDescription() == description;
            });
        tasks.erase(it, tasks.end());
    }

private:
    string name;
    string description;
    string startDate;
    string endDate;
    vector<Task> tasks;
};

class ProjectManager {
public:
    void createProject(const Project& project) {
        projects.push_back(project);
    }

    void displayProjects() {
        for (const auto& project : projects) {
        }
    }


private:
    vector<Project> projects;
};

int main() {
    ProjectManager projectManager;

    Project project1("Project1", "Description1", "2023-01-01", "2023-12-31");
    project1.addTask(Task("Task1", false, "2023-02-28"));
    project1.addTask(Task("Task2", false, "2023-03-15"));

    projectManager.createProject(project1);


    return 0;
}
