using MediTrack.Data;
using MediTrack.Repositories.Implementaions;
using MediTrack.Repositories.Interfaces;
using MediTrack.Services.Implimentations;
using MediTrack.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ----------------------
// 1. DbContext
// ----------------------
builder.Services.AddDbContext<MTDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);
// =========================
// User Management Services
// =========================
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IDoctorService, DoctorService>();
builder.Services.AddScoped<IPatientService, PatientService>();

// ===============================
// Appointments & Scheduling Services
// ===============================
builder.Services.AddScoped<IAppointmentService, AppointmentService>();
builder.Services.AddScoped<IDoctorAvailabilityService, DoctorAvailabilityService>();

// ===================================
// Electronic Health Records (EHR) Services
// ===================================
builder.Services.AddScoped<IMedicalRecordService, MedicalRecordService>();
builder.Services.AddScoped<IPrescriptionService, PrescriptionService>();
builder.Services.AddScoped<IPrescriptionDetailService, PrescriptionDetailService>();
builder.Services.AddScoped<ILabTestService, LabTestService>();

// ==============================
// Billing & Payments Services
// ==============================
builder.Services.AddScoped<IInvoiceService, InvoiceService>();
builder.Services.AddScoped<IPaymentService, PaymentService>();

// ======================================
// Communication & Notifications Services
// ======================================
builder.Services.AddScoped<INotificationService, NotificationService>();
builder.Services.AddScoped<IMessageService, MessageService>();

// ===========================
// System Management Services
// ===========================
builder.Services.AddScoped<IAuditLogService, AuditLogService>();
builder.Services.AddScoped<ISettingsService, SettingService>();

// ----------------------
// 2. User Management
// ----------------------
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IDoctorRepository, DoctorRepository>();
builder.Services.AddScoped<IPatientRepository, PatientRepository>();

// ----------------------
// 3. Appointments & Scheduling
// ----------------------
builder.Services.AddScoped<IAppointmentRepository, AppointmentRepository>();
builder.Services.AddScoped<IDoctorAvailabilityRepository, DoctorAvailabilityRepository>();

// ----------------------
// 4. Electronic Health Records (EHR)
// ----------------------
builder.Services.AddScoped<IMedicalRecordRepository, MedicalRecordRepository>();
builder.Services.AddScoped<IPrescriptionRepository, PrescriptionRepository>();
builder.Services.AddScoped<IPrescriptionDetailRepository, PrescriptionDetailRepository>();
builder.Services.AddScoped<ILabTestRepository, LabTestRepository>();

// ----------------------
// 5. Billing & Payments
// ----------------------
builder.Services.AddScoped<IInvoiceRepository, InvoiceRepository>();
builder.Services.AddScoped<IPaymentRepository, PaymentRepository>();

// ----------------------
// 6. Communication & Notifications
// ----------------------
builder.Services.AddScoped<INotificationRepository, NotificationRepository>();
builder.Services.AddScoped<IMessageRepository, MessageRepository>();

// ----------------------
// 7. System Management
// ----------------------
builder.Services.AddScoped<IAuditLogRepository, AuditLogRepository>();
builder.Services.AddScoped<ISettingsRepository, SettingsRepository>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
