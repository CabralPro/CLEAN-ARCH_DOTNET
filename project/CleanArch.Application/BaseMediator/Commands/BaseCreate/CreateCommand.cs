namespace CleanArch.Application.BaseMediator.Commands.BaseCreate
{
    public abstract class CreateCommand<TResponse, TDto> : BaseCreateCommand<TResponse, TDto>
    {
        public CreateCommand(TDto dto) : base(dto)
        {
        }
    }

    public abstract class CreateCommand<TDto> : BaseCreateCommand<TDto, TDto>
    {
        public CreateCommand(TDto dto) : base(dto)
        {
        }
    }
}
