public class GradeSchool
{
    private readonly Dictionary<int, List<string>> _allStudents 
        = new Dictionary<int, List<string>>();

    public bool Add(string student, int grade)
    {
        if (_allStudents.Values.Any(list => list.Contains(student)))
            return false;

        if (!_allStudents.ContainsKey(grade))
            _allStudents[grade] = new List<string>();

        _allStudents[grade].Add(student);

        _allStudents[grade].Sort();

        return true;
    }

    public IEnumerable<string> Roster()
    {
        return _allStudents
            .OrderBy(entry => entry.Key)
            .SelectMany(entry => entry.Value);
    }

    public IEnumerable<string> Grade(int grade)
    {
        if (_allStudents.TryGetValue(grade, out List<string> students))
            return students;

        return Enumerable.Empty<string>();
    }
}
