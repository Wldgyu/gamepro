// Fill out your copyright notice in the Description page of Project Settings.


#include "MyPawn.h"
#include "Cemera/CameraComponent.h"
#include "GameProject.h"

// Sets default values
AMyPawn::AMyPawn()
{
    PrimaryActorTick.bCanEverTick = true;
    AutoPossessPlayer = EAutoReceiveInput::Player0; // 플레이어 설정

    RootComponent = CreateDefaultSubobject<USceneComponent>(TEXT("RootComponent"));
    UCameraComponent* OurCamera = CreateDefaultSubobject<UCameraComponent>(TEXT("OurCamera"));
    OurVisibleComponent = CreateDefaultSubobject<UStaticMeshComponent>(TEXT("OurVisibleComponent")); // 카메라 및 카메라 암을 컴포넌트에 넣는 코드

    OurCamera->SetupAttachment(RootComponent);
    OurCamera->SetRelativeLocation(FVector(-250.0f, 0.0f, 250.0f));
    OurCamera->SetRelativeRotation(FRotator(-45.0f, 0.0f, 0.0f));
    OurVisibleComponent->SetupAttachment(RootComponent);
    // 카메라 위치 및 회전 세팅
}


// Called when the game starts or when spawned
void AMyPawn::BeginPlay()
{
	Super::BeginPlay();
	
}
void AMyPawn::Move_XAxis(float AxisValue)
{
    CurrentVelocity.X = FMath::Clamp(AxisValue, -1.0f, 1.0f) * 100.0f;
}
void AMyPawn::Move_YAxis(float AxisValue)
{
    CurrentVelocity.Y = FMath::Clamp(AxisValue, -1.0f, 1.0f) * 100.0f;
}
void AMyPawn::StartGrowing()
{
    bGrowing = true;
}
void AMyPawn::StopGrowing()
{
    bGrowing = false
}

// Called every frame
void AMyPawn::Tick(float DeltaTime)
{
    Super::Tick(DeltaTime);
    float CurrentScale = OurVisibleComponent->GetComponentScale().X;

    if (bGrowing)
    {
        // 1 초에 걸쳐 두 배 크기로 키우기
        CurrentScale += DeltaTime;
    }
    else
    {
        // 키운 속도대로 절반으로 줄이기
        CurrentScale -= (DeltaTime * 0.5f);
    }

    // 시작 크기 아래로 줄이거나 두 배 이상으로 키우지 않도록 함
    CurrentScale = FMath::Clamp(CurrentScale, 1.0f, 2.0f);
    OurVisibleComponent->SetWorldScale3D(FVector(CurrentScale));

    if (!CurrentVelocity.IsZero())
    {
        FVector NewLocation = GetActorLocation() + (CurrentVelocity * DeltaTime);
        SetActorLocation(NewLocation);
    }

}

// Called to bind functionality to input
void AMyPawn::SetupPlayerInputComponent(UInputComponent* PlayerInputComponent)
{
    Super::SetupPlayerInputComponent(PlayerInputComponent);
    InputComponent->BindAction("Grow", IE_Pressed, this, &AMyPawn::StartGrowing);
    InputComponent->BindAction("Grow", IE_Released, this, &AMyPawn::StopGrowing);

    InputComponent->BindAxis("MoveX", this, &AMyPawn::Move_XAxis);
    InputComponent->BindAxis("MoveY", this, &AMyPawn::Move_YAxis); // "MoveX"와 "MoveY" 두 이동 축의 값에 매 프레임 반응


}

