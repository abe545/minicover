﻿namespace MiniCover.Commands.Options
{
    internal class CoverageHitsFileOption : MiniCoverOption<string>
    {
        private const string DefaultValue = "coverage-hits.txt";
        public override string Description => $"Hits file name pattern [default: {DefaultValue}]";
        public override string OptionTemplate => "--hits-file";

        public override void Validate()
        {
            var proposalValue = Option.Value();
            if (string.IsNullOrWhiteSpace(proposalValue))
                proposalValue = DefaultValue;

            Validated = true;
            ValueField = proposalValue;
        }
    }
}