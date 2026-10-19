using Microsoft.AspNetCore.Components;
using MyPortfolio.Model;
using MyPortfolio.Services;
using Microsoft.AspNetCore.Components.Forms;
using System.IO;

public class ProfileBase : ComponentBase
{
    [Inject]
    public ICandidateService candidateService { get; set; } = null!;
    [Parameter]
    public string? userId { get; set; }

    public Candidate profileModel { get; set; } = new Candidate();
    public Candidate? editModel { get; set; }

    public bool _loaded = false;
    public bool showEditModal = false;
    public bool isSaving = false;
    public string? saveMessage;
    private const long MaxProfileImageSize = 5 * 1024 * 1024;

    public string? imageUploadError { get; set; }

    protected override async Task OnParametersSetAsync()
    {
        if (!Guid.TryParse(userId, out var candidateId))
        {
            profileModel = null!;
            _loaded = true;
            return;
        }

        await LoadCandidate(candidateId);
    }

    public async Task LoadCandidate(Guid candidateId)
    {
        _loaded = false;

        try
        {
            profileModel = await candidateService
                .GetCandidateProfileById(candidateId);
        }
        finally
        {
            _loaded = true;
        }
        StateHasChanged();
    }

    public void OpenEditModal()
    {
        if (profileModel == null)
            return;

        // Copy the scalar properties into a separate editing object.
        editModel = new Candidate
        {
            candidateId= profileModel.candidateId,
            firstName = profileModel.firstName,
            lastName = profileModel.lastName,
            email = profileModel.email,
            phoneNumber = profileModel.phoneNumber,
            gender = profileModel.gender,
            dob = profileModel.dob,
            careerObjective = profileModel.careerObjective,
            maritalStatus = profileModel.maritalStatus,
            userId = profileModel.userId,
            imagePath = profileModel.imagePath ?? "",
            address = profileModel.address ?? new List<Address>(profileModel.address),
            experiences = profileModel.experiences ?? new List<WorkExperience>(profileModel.experiences),
            educations = profileModel.educations ?? new List<Education>(profileModel.educations),
            skills = profileModel.skills ?? new List<Skill>(profileModel.skills),
            languages = profileModel.languages ?? new List<Language>(profileModel.languages),
            updatedAt = DateTime.UtcNow,
        };

        saveMessage = null;
        showEditModal = true;
    }

    public void CloseEditModal()
    {
        showEditModal = false;
        editModel = null;
        saveMessage = null;
    }

    public async Task SaveProfile()
    {
        if (editModel == null)
            return;

        isSaving = true;
        saveMessage = null;

        try
        {
            // Call your candidate update service here.
            await candidateService.UpdateCandidateProfile(editModel);

            if (Guid.TryParse(userId, out var candidateId))
                await LoadCandidate(candidateId);

            showEditModal = false;
            editModel = null;
        }
        catch (Exception ex)
        {
            saveMessage = "Unable to save profile. Please try again.";
            Console.Error.WriteLine(ex);
        }
        finally
        {
            isSaving = false;
        }
    }
    public void AddAddress() =>
    editModel?.address.Add(new Address
    {
        CandidateId = profileModel.candidateId,
        Address1 = string.Empty,
        Address2 = string.Empty,
        City = string.Empty,
        State = string.Empty,
        Country = string.Empty
    });

    public void AddExperience() =>
        editModel?.experiences.Add(new WorkExperience
        {
            CandidateId = profileModel.candidateId,
            CompanyName = string.Empty,
            Designation = string.Empty,
            Description = string.Empty,
            StartDate = string.Empty,
            EndDate = string.Empty
        });

    public void AddEducation() =>
        editModel?.educations.Add(new Education
        {
            CandidateId = profileModel.candidateId,
            InstitutionName = string.Empty,
            Specification = string.Empty,
            Address = string.Empty,
            StartDate = string.Empty,
            EndDate = string.Empty
        });

    public void AddSkill() =>
        editModel?.skills.Add(new Skill { SkillName = string.Empty, CandidateId = profileModel.candidateId, });

    public void AddLanguage() =>
        editModel?.languages.Add(new Language { Name = string.Empty, CandidateId = profileModel.candidateId, });

    private static readonly HashSet<string> AllowedImageTypes =
    new(StringComparer.OrdinalIgnoreCase)
    {
        "image/jpeg",
        "image/png",
        "image/gif",
        "image/webp"
    };

    public async Task HandleProfileImageUpload(InputFileChangeEventArgs e)
    {
        imageUploadError = null;

        if (editModel is null)
            return;

        var file = e.File;

        if (!AllowedImageTypes.Contains(file.ContentType))
        {
            imageUploadError = "Please upload a JPEG, PNG, GIF or WebP image.";
            return;
        }

        if (file.Size > MaxProfileImageSize)
        {
            imageUploadError = "The image must be 5 MB or smaller.";
            return;
        }

        try
        {
            await using var stream =
                file.OpenReadStream(MaxProfileImageSize);

            using var memoryStream = new MemoryStream();

            await stream.CopyToAsync(memoryStream);

            var base64 = Convert.ToBase64String(memoryStream.ToArray());

            editModel.imagePath =
                $"data:{file.ContentType};base64,{base64}";
        }
        catch (IOException)
        {
            imageUploadError = "Unable to read the selected image. Please try again.";
        }
        catch (InvalidOperationException)
        {
            imageUploadError = "Unable to process the image. Please try another file.";
        }
    }
}
